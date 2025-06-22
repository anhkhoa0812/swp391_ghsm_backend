using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayOSService.DTO;
using PayOSService.Services;
using Repository.Models;
using Repository.Util;

namespace API_GHSMS.Controllers
{
    [ApiController]
    [Route("api/v1/payment")]
    public class PaymentController(IPayOSService _service, Swp391ghsmContext _context) : Controller
    {
        [HttpPost("create-payment")]
        public async Task<IActionResult> CreatePayment([FromBody]Guid bookingId)
        {
           var getBooking = await _context.TestBookings.Include(x => x.Test).FirstOrDefaultAsync(x => x.TestBookingId == bookingId);

           var checkTransaction = await _context.Transaction.FirstOrDefaultAsync(x => x.BookingId == bookingId);
            if (checkTransaction != null)
            {
                return Ok(checkTransaction.Url);
            }

            if (getBooking == null)
            {
                return NotFound();
            }

            var paymentUrl = new CreatePaymentDTO
            {
                Content = "Payment",
                OrderCode = UserUtil.GenerateOrderCode(),
                RequiredAmount = (int)getBooking.Test.Price
            };

            string url = await _service.CreatePaymentAsync(paymentUrl);

            var createTransaction = new Transaction
            {
                Id = paymentUrl.OrderCode,
                BookingId = getBooking.TestBookingId,
                CreateAt = DateTime.Now,
                Url = url
            };

            await _context.Transaction.AddAsync(createTransaction);
            await _context.SaveChangesAsync();
            return Ok(url);
        }


        [HttpPost("return-payment")]
        public async Task<IActionResult>PaymentReturn([FromQuery]string code, [FromQuery] long orderId, [FromQuery] string status,[FromQuery]bool cancel)
        {
            var getBooking = await _context.Transaction
                                               .Include(x => x.TestBooking)
                                               .FirstOrDefaultAsync(x => x.Id == orderId);
            if (code == "00" && status == "PAID")
            {
  
                if(getBooking == null) { return NotFound(); }

                getBooking.TestBooking.Status = "PAID";
                 _context.Transaction.Update(getBooking);
                await _context.SaveChangesAsync();
                return Ok("Confirm Payment Success");
            }

            else
            {
                getBooking.TestBooking.Status = "Payment Cancelled";
                _context.Transaction.Update(getBooking);
                await _context.SaveChangesAsync();
                return Ok("Payment Cancelled");
            }
        }
    }
}
