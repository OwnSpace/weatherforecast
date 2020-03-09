using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using WeatherForecast.Core.Filters;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.Api.Resources.Filters
{
    public sealed class CountryFilter : EntityPageFilterBase<Country>
    {
        public string Name { get; set; }

        protected override IEnumerable<Expression<Func<Country, bool>>> FilterConditions()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return Enumerable.Empty<Expression<Func<Country, bool>>>();
            }

            return new List<Expression<Func<Country, bool>>> { c => c.Name.StartsWith(Name) };
        }
    }
}
