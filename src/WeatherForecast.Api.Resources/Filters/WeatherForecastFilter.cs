using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

using WeatherForecast.Api.Resources.Filters.Exceptions;
using WeatherForecast.Core.Filters;

namespace WeatherForecast.Api.Resources.Filters
{
    public sealed class WeatherForecastFilter : EntityPageFilterBase<Domain.Models.WeatherForecast>
    {
        [Required]
        public DateTime Date { get; set; }

        public string City { get; set; }

        public Guid? CityId { get; set; }

        protected override IEnumerable<Expression<Func<Domain.Models.WeatherForecast, bool>>> FilterConditions()
        {
            var conditions = new List<Expression<Func<Domain.Models.WeatherForecast, bool>>>();
            if (!string.IsNullOrWhiteSpace(City))
            {
                conditions.Add(a => a.City.Name == City);
            }
            else if (CityId.HasValue && CityId != Guid.Empty)
            {
                conditions.Add(a => a.City.Id == CityId);
            }
            else
            {
                throw new CorruptedFilterException<WeatherForecastFilter, Domain.Models.WeatherForecast>(this);
            }

            if (Date != default)
            {
                conditions.Add(a => Date.Date <= a.Date.Date && a.Date.Date <= Date.Date.AddDays(10));
            }

            return conditions;
        }
    }
}
