using Autofac;
using MeetupBooking.Services.Interfaces;
using MeetupBooking.Services.Services;

namespace MeetupBooking.Infrastructure.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MeetupService>().As<IMeetupService>();
            builder.RegisterType<RoomService>().As<IRoomService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
