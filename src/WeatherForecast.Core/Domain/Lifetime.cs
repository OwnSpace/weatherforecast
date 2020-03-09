using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Core.Domain
{
    [NotMapped]
    public class Lifetime
    {
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
