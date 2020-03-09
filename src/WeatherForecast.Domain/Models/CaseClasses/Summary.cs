using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Domain.Models.CaseClasses
{
    [NotMapped]
    public class Summary : CaseClass<Summary, string>
    {
        public Summary()
        {
        }

        private Summary(string value) => Value = value;

        public static implicit operator string(Summary @class) => @class.Value;

        public static implicit operator Summary(string value) => new Summary(value);
    }
}
