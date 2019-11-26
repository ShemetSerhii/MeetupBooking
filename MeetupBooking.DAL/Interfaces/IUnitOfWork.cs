using MeetupBooking.DAL.Interfaces.Repository;
using System.Threading.Tasks;

namespace MeetupBooking.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IMeetupRepository MeetupRepository { get; }

        IRoomRepository RoomRepository { get; }

        IUserRepository UserRepository { get; }

        IBookingRepository BookingRepository { get; }

        IParticipantRepository ParticipantRepository { get; }

        Task SaveAsync();
    }
}
