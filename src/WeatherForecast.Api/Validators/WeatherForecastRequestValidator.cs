using FluentValidation;
using WeatherForecast.Api.Resources.Requests;

namespace WeatherForecast.Api.Validators
{
    public class WeatherForecastRequestValidator : AbstractValidator<WeatherForecastRequest>
    {
        public WeatherForecastRequestValidator()
        {
            RuleFor(cmd => cmd.Date).NotEmpty().WithMessage("{PropertyName} должно быть указано");
            RuleFor(cmd => cmd.City).NotEmpty().WithMessage("{PropertyName} должно быть указано");
        }
    }
}
