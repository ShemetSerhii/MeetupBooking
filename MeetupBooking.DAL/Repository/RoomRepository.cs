using MeetupBooking.DAL.Context;
using MeetupBooking.DAL.Interfaces.Repository;
using MeetupBooking.Domain.Entities;

namespace MeetupBooking.DAL.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(MeetupBookingDbContext context)
            : base(context)
        {
        }
    }
}
