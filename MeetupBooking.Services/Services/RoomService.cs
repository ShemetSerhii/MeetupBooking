using MeetupBooking.DAL.Interfaces;
using MeetupBooking.Services.Interfaces;

namespace MeetupBooking.Services.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
