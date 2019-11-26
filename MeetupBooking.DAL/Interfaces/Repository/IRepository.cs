using MeetupBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeetupBooking.DAL.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        Task<TEntity> GetAsync(int id);

        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntity, object>>[] includes);


        Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filters = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            params Expression<Func<TEntity, object>>[] includes);
    }
}
