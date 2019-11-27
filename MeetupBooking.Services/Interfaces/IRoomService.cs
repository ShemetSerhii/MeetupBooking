using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetupBooking.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetRooms();

        Task CancelBooking(int roomId, int meetupId);

        Task Book(int meetupId, BookingDto booking);
    }
}
