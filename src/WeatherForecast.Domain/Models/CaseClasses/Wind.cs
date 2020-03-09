using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Domain.Models.CaseClasses
{
    [NotMapped]
    public sealed class Wind : CaseClass<Wind, float>
    {
        public Wind()
        {
        }

        private Wind(float value) => Value = value;

        public static implicit operator float(Wind @class) => @class.Value;

        public static implicit operator Wind(float value) => new Wind(value);
    }
}
