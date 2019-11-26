using MeetupBooking.DAL.Context;
using MeetupBooking.DAL.Interfaces.Repository;
using MeetupBooking.Domain.Entities;

namespace MeetupBooking.DAL.Repository
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(MeetupBookingDbContext context)
            : base(context)
        { }
    }
}
