using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using WeatherForecast.Core.Filters;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.Api.Resources.Filters
{
    public sealed class CityFilter : EntityPageFilterBase<City>
    {
        public static readonly CityFilter Empty = new CityFilter();

        public CityFilter()
            : base()
        {
            // note: temp solution to obtain probably all cities
            PageSize = 500;
        }

        public string Name { get; set; }

        public string IATA { get; set; }

        protected override IEnumerable<Expression<Func<City, bool>>> FilterConditions()
        {
            if (!string.IsNullOrEmpty(IATA))
            {
                return new List<Expression<Func<City, bool>>> { c => c.IATA.StartsWith(Name) };
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                return new List<Expression<Func<City, bool>>> { c => c.Name.StartsWith(Name) };
            }

            return Enumerable.Empty<Expression<Func<City, bool>>>();
        }
    }
}
