using Autofac;
using MeetupBooking.DAL.Context;
using MeetupBooking.DAL.Interfaces;
using MeetupBooking.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace MeetupBooking.Infrastructure.Modules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<MeetupBookingDbContext>()
                    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MeetupBooking;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                return new MeetupBookingDbContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
