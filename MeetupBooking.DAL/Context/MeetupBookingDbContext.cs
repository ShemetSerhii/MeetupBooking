using MeetupBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetupBooking.DAL.Context
{
    public class MeetupBookingDbContext : DbContext
    {
        public MeetupBookingDbContext(DbContextOptions<MeetupBookingDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Meetup> Meetups { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
