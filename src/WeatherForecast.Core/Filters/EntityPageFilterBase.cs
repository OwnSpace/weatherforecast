using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using WeatherForecast.Core.Domain;

namespace WeatherForecast.Core.Filters
{
    public abstract class EntityPageFilterBase<TEntity> : AbstractPagingFilter<TEntity>
        where TEntity : ILifetime
    {
        public bool IncludeDeleted { get; set; }

        protected override sealed IEnumerable<Expression<Func<TEntity, bool>>> Conditions
        {
            get
            {
                if (!IncludeDeleted)
                {
                    var filterConditions = FilterConditions().ToList();

                    // ToDo: move deleted to Archive on delete - don't filter 'em so here
                    filterConditions.Add(a => a.Lifetime.DeletedAt == default);

                    return filterConditions;
                }

                return FilterConditions();
            }
        }

        protected virtual IEnumerable<Expression<Func<TEntity, bool>>> FilterConditions() => Enumerable.Empty<Expression<Func<TEntity, bool>>>();
    }
}
