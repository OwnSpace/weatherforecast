using WeatherForecast.Core.Domain;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.Domain.Models.Abstract
{
    public abstract class GeoEntity : Entity
    {
        public GeoPoint GeoPoint { get; set; }
    }
}
