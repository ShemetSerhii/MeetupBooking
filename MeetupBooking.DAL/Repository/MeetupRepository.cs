using MeetupBooking.DAL.Context;
using MeetupBooking.DAL.Interfaces.Repository;
using MeetupBooking.Domain.Entities;

namespace MeetupBooking.DAL.Repository
{
    public class MeetupRepository : Repository<Meetup>, IMeetupRepository
    {
        public MeetupRepository(MeetupBookingDbContext context)
            : base(context)
        {
        }
    }
}
