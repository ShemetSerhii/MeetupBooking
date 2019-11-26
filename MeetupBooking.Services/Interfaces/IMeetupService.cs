using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Models;
using System.Threading.Tasks;

namespace MeetupBooking.Services.Interfaces
{
    public interface IMeetupService
    {
        Task CreateAsync(MeetupDtoModel meetup);

        Task UpdateAsync(Meetup meetup);

        Task<Meetup> Get(int id);

        Task Delete(int id);
    }
}
