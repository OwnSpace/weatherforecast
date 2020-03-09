using System;

using WeatherForecast.Domain.Models.Abstract;

namespace WeatherForecast.Domain.Models.Geo
{
    public sealed class City : GeoEntity
    {
        public string Name { get; set; }

        public string IATA { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }
    }
}
