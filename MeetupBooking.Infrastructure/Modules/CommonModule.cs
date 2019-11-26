using Autofac;
using MeetupBooking.Common.Interfaces;
using MeetupBooking.Common.Mapping;

namespace MeetupBooking.Infrastructure.Modules
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MappingService>().As<IMappingService>();
        }
    }
}
