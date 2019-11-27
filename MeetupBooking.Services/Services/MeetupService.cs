using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            await BookRoom(newMeetup, meetupDto.Bookings);
            await InviteParticipants(newMeetup, meetupDto.Participants);

            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var meetup = await _unitOfWork.MeetupRepository.GetAsync(id);

            _unitOfWork.MeetupRepository.Delete(meetup);

            await _unitOfWork.SaveAsync();
        }

        public  Task<IEnumerable<Meetup>> Find(Expression<Func<Meetup, bool>> filter)
        {
            return _unitOfWork.MeetupRepository
                .GetAsync(filter,
                          null,
                          null,
                          null,
                          x => x.Participants,
                          x => x.Owner,
                          x => x.Rooms);
        }

        public Task<Meetup> Get(int id)
        {
            return _unitOfWork.MeetupRepository
                .FirstOrDefaultAsync(x => x.Id == id,
                                     null,
                                     x => x.Rooms,
                                     x => x.Participants,
                                     x => x.Owner);
        }

        public Task<IEnumerable<Meetup>> GetAll()
        {
            return _unitOfWork.MeetupRepository
                .GetAsync(null, 
                          null, 
                          null, 
                          null,
                          x => x.Rooms,
                          x => x.Owner,
                          x => x.Participants);
        }

        public async Task Invitate(int meetupId, int userId)
        {
            await _unitOfWork.ParticipantRepository.CreateAsync(new Participant
            {
                MeetupId = meetupId,
                UserId = userId
            });

            await _unitOfWork.SaveAsync();
        }

        public async Task Invitate(int meetupId, int[] usersId)
        {
            foreach(var userId in usersId)
            {
               await Invitate(meetupId, usersId);
            }
        }

        public async Task UpdateAsync(Meetup meetup)
        {
            _unitOfWork.MeetupRepository.Update(meetup);

            await _unitOfWork.SaveAsync();
        }

        private async Task BookRoom(Meetup meetup, ICollection<BookingDto> bookings)
        {
            var rooms = await _unitOfWork.RoomRepository.GetAsync(room => bookings.Select(booking => booking.RoomId).Contains(room.Id));

            foreach(var room in rooms)
            {
                var booking = bookings.FirstOrDefault(book => book.RoomId == room.Id);

                await _unitOfWork.BookingRepository.CreateAsync(new Booking
                {
                    Meetup = meetup,
                    MeetupId = meetup.Id,
                    Room = room,
                    RoomId = room.Id,
                    DateFrom = booking.DateFrom,
                    DateTo = booking.DateTo
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
