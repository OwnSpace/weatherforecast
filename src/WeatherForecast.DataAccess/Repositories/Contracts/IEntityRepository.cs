using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using WeatherForecast.Core.Domain;

namespace WeatherForecast.DataAccess.Repositories.Contracts
{
    public interface IEntityRepository<TEntity>
        where TEntity : Entity
    {
        IQueryable<TEntity> Query { get; }

        Task<TEntity> GetAsync(Guid id);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, int? topCount = default);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> SaveAsync(TEntity entity);

        ValueTask<bool> RemoveAsync(Guid id);

        ValueTask<bool> RemoveAsync(TEntity entity);
    }
}
