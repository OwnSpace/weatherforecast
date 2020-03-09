using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using WeatherForecast.Domain.Models.Abstract;

namespace WeatherForecast.Domain.Models.Geo
{
    public sealed class Country : GeoEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        [InverseProperty(nameof(City.Country))]
        public IEnumerable<City> Cities { get; } = new List<City>();
    }
}
