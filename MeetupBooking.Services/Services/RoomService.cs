using System.Collections.Generic;
using System.Threading.Tasks;
using MeetupBooking.DAL.Interfaces;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Interfaces;
using MeetupBooking.Services.Models;

namespace MeetupBooking.Services.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Book(int meetupId, BookingDto booking)
        {
            await _unitOfWork.BookingRepository.CreateAsync(new Booking 
            { 
                MeetupId = meetupId,
                RoomId = booking.RoomId,
                DateFrom = booking.DateFrom,
                DateTo = booking.DateTo
            });

            await _unitOfWork.SaveAsync();
        }

        public async Task CancelBooking(int roomId, int meetupId)
        {
            var booking = await _unitOfWork.BookingRepository
                .FirstOrDefaultAsync(b => b.RoomId == roomId && b.MeetupId == meetupId);

            _unitOfWork.BookingRepository.Delete(booking);

            await _unitOfWork.SaveAsync();
        }

        public Task<IEnumerable<Room>> GetRooms()
        {
            return _unitOfWork.RoomRepository.GetAsync();
        }
    }
}
