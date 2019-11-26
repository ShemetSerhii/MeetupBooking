using MeetupBooking.DAL.Context;
using MeetupBooking.DAL.Interfaces.Repository;
using MeetupBooking.Domain.Entities;

namespace MeetupBooking.DAL.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(MeetupBookingDbContext context)
          : base(context)
        {
        }
    }
}
