using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.DTO;
using Repository.Models;
using Repository.Models.Enum;

namespace Repository.Repository
{
    public class BookingRepository(Swp391ghsmContext _context) : GenericRepository<TestBooking>
    {
        public async Task<string> Booking(BookingDTO request)
        {
            try
            {
                var checkBookingDate = await _context.TestBookings
                                     .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.TestId == request.TestId);
                if (checkBookingDate != null)
                {
                    return "208";
                }

                var getTest = await _context.Tests.FirstOrDefaultAsync(x => x.TestId == request.TestId);
                getTest.isBooked = true;

                 _context.Tests.Update(getTest);
                var createBooking = new TestBooking
                {
                    TestBookingId = Guid.NewGuid(),
                    UserId = request.UserId,
                    TestId = request.TestId,
                    ScheduledDate = getTest.Date,
                    Status = "Wait For Payment"
                };

                await _context.TestBookings.AddAsync(createBooking);
                await _context.SaveChangesAsync();
                return createBooking.TestBookingId.ToString();
            }
            catch (Exception ex) {
                throw new Exception(ex.ToString());
            }

        }

        public async Task<List<GetBookingByUserResponse>>GetBookingByUser(Guid userId)
        {
            var getBookings = await _context.TestBookings.Where(x => x.UserId == userId).ToListAsync();

            var mapItem = getBookings.Select(x => new GetBookingByUserResponse
            {
                TestBookingId = x.TestBookingId,
                scheduledDate = x.ScheduledDate,
                Status = x.Status
            }).ToList();

            return mapItem;
        }     
        
    }
}
