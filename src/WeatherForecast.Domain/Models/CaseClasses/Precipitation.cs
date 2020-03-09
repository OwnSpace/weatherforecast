using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Domain.Models.CaseClasses
{
    [NotMapped]
    public sealed class Precipitation : CaseClass<Precipitation, float>
    {
        public Precipitation()
        {
        }

        private Precipitation(float value) => Value = value;

        public static implicit operator float(Precipitation @class) => @class.Value;

        public static implicit operator Precipitation(float value) => new Precipitation(value);
    }
}
