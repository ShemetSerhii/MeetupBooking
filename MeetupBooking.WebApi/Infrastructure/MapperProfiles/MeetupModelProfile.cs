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
            CreateMap<MeetupDtoModel, Meetup>();
        }
    }
}
