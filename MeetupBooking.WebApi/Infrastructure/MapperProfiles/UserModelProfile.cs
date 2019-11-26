using AutoMapper;
using MeetupBooking.Domain.Entities;
using MeetupBooking.WebApi.Models.Account;

namespace MeetupBooking.WebApi.Infrastructure.MapperProfiles
{
    public class UserModelProfile : Profile
    {
        public UserModelProfile()
        {
            CreateMap<RegisterModel, User>();
        }
    }
}
