using MeetupBooking.DAL.Context;
using MeetupBooking.DAL.Interfaces;
using MeetupBooking.DAL.Interfaces.Repository;
using MeetupBooking.DAL.Repository;
using System;
using System.Threading.Tasks;

namespace MeetupBooking.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeetupBookingDbContext _context;
        private readonly Lazy<IMeetupRepository> _meetupRepository;
        private readonly Lazy<IRoomRepository> _roomRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IBookingRepository> _bookingRepository;
        private readonly Lazy<IParticipantRepository> _participantRepository;

        public UnitOfWork(MeetupBookingDbContext context)
        {
            _context = context;

            _meetupRepository = new Lazy<IMeetupRepository>(() => new MeetupRepository(context));
            _roomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _bookingRepository = new Lazy<IBookingRepository>(() => new BookingRepository(context));
            _participantRepository = new Lazy<IParticipantRepository>(() => new ParticipantRepository(context));
        }

        public IMeetupRepository MeetupRepository => _meetupRepository.Value;

        public IRoomRepository RoomRepository => _roomRepository.Value;

        public IUserRepository UserRepository => _userRepository.Value;

        public IBookingRepository BookingRepository => _bookingRepository.Value;

        public IParticipantRepository ParticipantRepository => _participantRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
