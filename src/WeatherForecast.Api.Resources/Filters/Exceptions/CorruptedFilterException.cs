using System;

using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Filters;

namespace WeatherForecast.Api.Resources.Filters.Exceptions
{
    public class CorruptedFilterException<TFilter, TEntity> : Exception
        where TFilter : AbstractPagingFilter<TEntity>
        where TEntity : Entity
    {
        public CorruptedFilterException(TFilter filter)
            : base(filter.ToString())
        {
        }
    }
}
