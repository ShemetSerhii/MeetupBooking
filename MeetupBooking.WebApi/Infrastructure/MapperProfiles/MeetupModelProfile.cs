using AutoMapper;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Models;
using MeetupBooking.WebApi.Models.Meetup;

namespace MeetupBooking.WebApi.Infrastructure.MapperProfiles
{
    public class MeetupModelProfile : Profile
    {
        public MeetupModelProfile()
        {
            CreateMap<MeetupCreateModel, MeetupDtoModel>();
            CreateMap<MeetupDtoModel, Meetup>()
                .ForMember(m => m.Participants, m => m.Ignore());
            CreateMap<BookingModel, BookingDto>();
            CreateMap<Meetup, MeetupViewModel>()
                .ForMember(m => m.Participants, m => m.Ignore())
                .ForMember(m => m.Rooms, m => m.Ignore())
                .ForMember(m => m.OwnerName, m => m.MapFrom(x => $"{x.Owner.FirstName} {x.Owner.LastName}"));
        }
    }
}
