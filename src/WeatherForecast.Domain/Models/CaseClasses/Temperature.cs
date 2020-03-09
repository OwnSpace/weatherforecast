using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Domain.Models.CaseClasses
{
    [NotMapped]
    public sealed class Temperature : CaseClass<Temperature, float>
    {
        public static readonly Temperature AbsoluteZero = -273.15f;

        public Temperature()
        {
        }

        private Temperature(float value) => Value = value;

        public static implicit operator float(Temperature @class) => @class.Value;

        public static implicit operator Temperature(float value) => new Temperature(value);
    }
}
