using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WeatherForecast.Core.Domain;
using WeatherForecast.DataAccess.Contexts;
using WeatherForecast.DataAccess.Repositories.Contracts;

namespace WeatherForecast.DataAccess.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : Entity, ILifetime
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public EntityRepository(DataContext context)
        {
            Context = context;
        }

        public virtual IQueryable<TEntity> Query => Entities;

        private DataContext Context { get; }

        private DbSet<TEntity> Entities => Context.Set<TEntity>();

        public virtual async Task<TEntity> GetAsync(Guid id) =>
            await OnEntityLookup(e => e.Id == id).FirstOrDefaultAsync();

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, int? topCount = default)
        {
            return await
                (topCount == default
                    ? OnEntityLookup(predicate).AsNoTracking()
                    : OnEntityLookup(predicate).AsNoTracking().Take(topCount.Value)).ToListAsync();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await OnEntityLookup(predicate).AsNoTracking().Take(1).AnyAsync();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entry = await Context.AddAsync(entity);

            await Context.SaveChangesAsync();

            return entry.Entity;
        }

        public virtual async Task<TEntity> SaveAsync(TEntity entity)
        {
            await Context.SaveChangesAsync();

            return entity;
        }

        public async ValueTask<bool> RemoveAsync(Guid id)
        {
            var entity = await GetAsync(id);

            return await RemoveAsync(entity);
        }

        public async ValueTask<bool> RemoveAsync(TEntity entity)
        {
            if (entity == default)
            {
                return false;
            }

            Entities.Remove(entity);

            return await Context.SaveChangesAsync() > 0;
        }

        protected virtual IQueryable<TEntity> OnEntityLookup(Expression<Func<TEntity, bool>> predicate) => Entities.Where(predicate);
    }
}
