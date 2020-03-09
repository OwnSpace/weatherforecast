using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Domain.Models.Geo
{
    [NotMapped]
    public sealed class GeoPoint
    {
        public float Lat { get; set; }

        public float Lng { get; set; }
    }
}
