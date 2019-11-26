using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeetupBooking.DAL.Context
{
    public class DatabaseFactory : IDesignTimeDbContextFactory<MeetupBookingDbContext>
    {
        public MeetupBookingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeetupBookingDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MeetupBooking;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new MeetupBookingDbContext(optionsBuilder.Options);
        }
    }
}
