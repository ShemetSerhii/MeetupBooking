using MeetupBooking.Domain.Entities;
using System.Threading.Tasks;

namespace MeetupBooking.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(int id);

        Task<User> GetUser(string email);

        Task<User> GetUser(string email, string password);

        Task Register(User user);

        Task Update(User user);
    }
}
