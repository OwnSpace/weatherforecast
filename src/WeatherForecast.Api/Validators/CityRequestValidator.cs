using FluentValidation;
using WeatherForecast.Api.Resources.Requests;

namespace WeatherForecast.Api.Validators
{
    public class CityRequestValidator : AbstractValidator<CityRequest>
    {
        public CityRequestValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty().WithMessage("{PropertyName} указано быть указано");
        }
    }
}
