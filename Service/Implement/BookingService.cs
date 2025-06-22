using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DTO;
using Repository.Repository;
using Service.Interface;

namespace Service.Implement
{
    public class BookingService(BookingRepository _bookingRepository) : IBookingService
    {
        public async Task<string> Booking(BookingDTO request)
        {
           return await _bookingRepository.Booking(request);
        }
    }
}
