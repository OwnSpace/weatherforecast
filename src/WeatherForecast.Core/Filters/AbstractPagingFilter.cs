using System;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Core.Filters
{
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
    public abstract class AbstractPagingFilter<TEntity> : AbstractFilter<TEntity>
    {
        protected AbstractPagingFilter()
        {
            Page = 1;
            PageSize = 10;
            MaxPageSize = 1000;
        }

        public int MaxPageSize { get; protected set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool CountOnly { get; set; } = false;

        public override (IQueryable<TEntity> Data, Func<Task<int>> Total) ApplyTo(IQueryable<TEntity> query)
        {
            if (PageSize <= 0)
            {
                PageSize = MaxPageSize;
            }

            var (queryable, total) = base.ApplyTo(query);
            return (queryable.Skip((Page - 1) * PageSize).Take(PageSize), total);
        }
    }
}
