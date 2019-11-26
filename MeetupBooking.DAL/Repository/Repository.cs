using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MeetupBooking.DAL.Context;
using MeetupBooking.DAL.Interfaces.Repository;
using MeetupBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetupBooking.DAL.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MeetupBookingDbContext Context;
        protected DbSet<TEntity> EntitySet;

        protected Repository(MeetupBookingDbContext context)
        {
            Context = context;
            EntitySet = Context.Set<TEntity>();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await EntitySet.AddAsync(entity);

            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            EntitySet.Remove(entity);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filters = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = EntitySet;

            if (includes.Any())
            {
                query = Include(includes);
            }

            if (order != null)
            {
                query = order(query);
            }

            return filters == null ?
                EntitySet.FirstOrDefaultAsync()
                : query.FirstOrDefaultAsync(filters);
        }

        public  virtual Task<TEntity> GetAsync(int id)
        {
            return EntitySet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filters = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null, int? skip = null, int? take = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = EntitySet;

            if (includes.Any())
            {
                query = Include(includes);
            }

            if (filters != null)
            {
                query = query.Where(filters);
            }

            if (skip.HasValue && take.HasValue)
            {
                if (skip.Value < 0)
                {
                    throw new Exception("Skip can not be less than zero");
                }

                if (take.Value <= 0)
                {
                    throw new Exception("Take can not be less than or equal zero");
                }

                query = query.Skip(skip.Value).Take(take.Value);
            }

            if (order != null)
            {
                query = order(query);
            }

            return await query.ToListAsync();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = EntitySet.AsNoTracking();

            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
