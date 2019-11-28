using AutoMapper;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Models;
using MeetupBooking.WebApi.Models.Booking;
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
            CreateMap<Booking, BookingViewModel>()
                .ForMember(b => b.RoomName, b => b.MapFrom(x => x.Room.Name))
                .ForMember(b => b.TimeFrom, b => b.MapFrom(x => x.DateFrom))
                .ForMember(b => b.TimeTo, b => b.MapFrom(x => x.DateTo));
            CreateMap<Meetup, MeetupViewModel>()
                .ForMember(m => m.Rooms, m => m.Ignore())
                .ForMember(m => m.Participants, m => m.MapFrom(x => x.Participants.Select(r => r.UserId)));
            CreateMap<Meetup, MeetupViewModelList>()
                .ForMember(m => m.Rooms, m => m.MapFrom(x => x.Rooms.Select(r => r.Id)))
                .ForMember(m => m.Participants, m => m.MapFrom(x => x.Participants.Select(r => r.UserId)));
        }
    }
}
