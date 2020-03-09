using System;

using WeatherForecast.Core.Domain;
using WeatherForecast.Domain.Models.CaseClasses;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.Domain.Models
{
    public sealed class WeatherForecast : Entity
    {
        private string cityName;

        public DateTime Date { get; set; }

        public Summary Summary { get; set; }

        public Temperature MinTemperature { get; set; }

        public Temperature MaxTemperature { get; set; }

        public Precipitation Precipitation { get; set; }

        public Wind Wind { get; set; }

        public Guid CityId { get; set; }

        public City City { get; set; }

        public string CityName
        {
            get => cityName ?? City.Name;
            set => cityName = value;
        }

        public Country Country => City.Country;
    }
}
