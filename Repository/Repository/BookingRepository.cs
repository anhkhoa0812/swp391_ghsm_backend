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
                                     .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.ScheduleId == request.ScheduleId);
                if (checkBookingDate != null)
                {
                    return "208";
                }

                var getSchedule = await _context.ConsultantUserSchedules.FirstOrDefaultAsync(x => x.ScheduleId == request.ScheduleId);
                var createBooking = new TestBooking
                {
                    TestBookingId = Guid.NewGuid(),
                    UserId = request.UserId,
                    ScheduleId = request.ScheduleId,
                    TestId = request.TestId,
                    ScheduledDate = getSchedule.ScheduleDateTime,
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
    }
}
