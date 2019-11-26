namespace MeetupBooking.Domain.Entities
{
    public class Participant : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int MeetupId { get; set; }

        public Meetup Meetup { get; set; }
    }
}
