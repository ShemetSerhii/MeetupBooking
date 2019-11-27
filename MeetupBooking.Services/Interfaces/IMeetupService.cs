using MeetupBooking.Domain.Entities;
using MeetupBooking.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeetupBooking.Services.Interfaces
{
    public interface IMeetupService
    {
        Task CreateAsync(MeetupDtoModel meetup);

        Task UpdateAsync(Meetup meetup);

        Task<Meetup> Get(int id);

        Task<IEnumerable<Meetup>> GetAll();

        Task<IEnumerable<Meetup>> Find(Expression<Func<Meetup, bool>> filter);

        Task Delete(int id);

        Task Invitate(int meetupId, int userId);

        Task Invitate(int meetupId, int[] usersId);
    }
}
