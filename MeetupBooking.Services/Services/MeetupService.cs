using System.Collections.Generic;
using System.Threading.Tasks;
using MeetupBooking.Common.Interfaces;
using MeetupBooking.DAL.Interfaces;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Interfaces;
using MeetupBooking.Services.Models;

namespace MeetupBooking.Services.Services
{
    public class MeetupService : IMeetupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMappingService _mappingService;

        public MeetupService(IUnitOfWork unitOfWork, IMappingService mappingService)
        {
            _unitOfWork = unitOfWork;
            _mappingService = mappingService;
        }

        public async Task CreateAsync(MeetupDtoModel meetupDto)
        {
            var meetup = _mappingService.Map<MeetupDtoModel, Meetup>(meetupDto);

            var newMeetup = await _unitOfWork.MeetupRepository.CreateAsync(meetup);

            await BookRoom(newMeetup, meetupDto.RoomsId);
            await InviteParticipants(newMeetup, meetupDto.Participants);

            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var meetup = await _unitOfWork.MeetupRepository.GetAsync(id);

            _unitOfWork.MeetupRepository.Delete(meetup);

            await _unitOfWork.SaveAsync();
        }

        public Task<Meetup> Get(int id)
        {
            return _unitOfWork.MeetupRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Meetup meetup)
        {
            _unitOfWork.MeetupRepository.Update(meetup);

            await _unitOfWork.SaveAsync();
        }

        private async Task BookRoom(Meetup meetup, ICollection<int> RoomsId)
        {
            var rooms = await _unitOfWork.RoomRepository.GetAsync(room => RoomsId.Contains(room.Id));

            foreach(var room in rooms)
            {
                await _unitOfWork.BookingRepository.CreateAsync(new Booking
                {
                    Meetup = meetup,
                    MeetupId = meetup.Id,
                    Room = room,
                    RoomId = room.Id
                });
            }
        }

        private async Task InviteParticipants(Meetup meetup, ICollection<int> UsersId)
        {
            var users = await _unitOfWork.UserRepository.GetAsync(user => UsersId.Contains(user.Id));

            foreach(var user in users)
            {
                await _unitOfWork.ParticipantRepository.CreateAsync(new Participant
                {
                    Meetup = meetup,
                    MeetupId = meetup.Id,
                    User = user,
                    UserId = user.Id
                });
            }
        }
    }
}
