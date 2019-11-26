using AutoMapper;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Models;
using MeetupBooking.WebApi.Models.Meetup;
using System.Linq;

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
                .ForMember(m => m.Rooms, m => m.MapFrom(x => x.Rooms.Select(r => r.RoomId)))
                .ForMember(m => m.Participants, m => m.MapFrom(x => x.Participants.Select(r => r.UserId)));
        }
    }
}
