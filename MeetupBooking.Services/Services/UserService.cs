using System;
using System.Linq;
using System.Threading.Tasks;
using MeetupBooking.DAL.Interfaces;
using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Interfaces;

namespace MeetupBooking.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUser(string login, string password)
        {
            var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(us => us.Email == login && us.Password.GetHashCode() == password.GetHashCode());

            return user;
        }

        public async Task<User> GetUser(string email)
        {
            var user = await _unitOfWork.UserRepository.FirstOrDefaultAsync(us => us.Email == email);

            return user;
        }

        public async Task Register(User user)
        {
            await ValidateEmail(user.Email);

            await _unitOfWork.UserRepository.CreateAsync(user);

            await _unitOfWork.SaveAsync();
        }

        public Task Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);

            return _unitOfWork.SaveAsync();
        }

        private async Task ValidateEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(us => us.Email == email);

            if (user.Any())
                throw new Exception("This email already exists");
        }
    }
}
