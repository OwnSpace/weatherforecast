using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using WeatherForecast.Core.Extensions;

namespace WeatherForecast.Core.Filters
{
    public abstract class AbstractFilter<TEntity>
    {
        protected abstract IEnumerable<Expression<Func<TEntity, bool>>> Conditions { get; }

        public virtual (IQueryable<TEntity> Data, Func<Task<int>> Total) ApplyTo(IQueryable<TEntity> query) =>
            Conditions.Any() ? Applied(query) : Default(query);

        protected virtual (IQueryable<TEntity> Data, Func<Task<int>> Total) Applied(IQueryable<TEntity> query)
        {
            var filter = Conditions.Skip(1).Aggregate(Conditions.First(), (current, condition) => current.AndAlso(condition));
            var queryable = query.Where(filter);
            return (queryable, () => queryable.CountAsync());
        }

        private static (IQueryable<TEntity> Data, Func<Task<int>> Total) Default(IQueryable<TEntity> query) => (query, () => query.CountAsync());
    }
}
