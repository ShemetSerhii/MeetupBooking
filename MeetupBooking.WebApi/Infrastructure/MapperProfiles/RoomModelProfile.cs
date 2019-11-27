using AutoMapper;
using MeetupBooking.Domain.Entities;
using MeetupBooking.WebApi.Models.Room;

namespace MeetupBooking.WebApi.Infrastructure.MapperProfiles
{
    public class RoomModelProfile : Profile
    {
        public RoomModelProfile()
        {
            CreateMap<Room, RoomViewModel>();
        }
    }
}
