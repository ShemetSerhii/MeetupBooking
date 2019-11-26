using MeetupBooking.DAL.Context;
using MeetupBooking.DAL.Interfaces.Repository;
using MeetupBooking.Domain.Entities;

namespace MeetupBooking.DAL.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MeetupBookingDbContext context)
            : base(context)
        {

        }
    }
}
