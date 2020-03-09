using FluentValidation;
using WeatherForecast.Api.Resources.Requests;

namespace WeatherForecast.Api.Validators
{
    public class CountryRequestValidator : AbstractValidator<CountryRequest>
    {
        public CountryRequestValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty().WithMessage("{PropertyName} указано быть указано");
        }
    }
}
