using Microsoft.Extensions.Logging;
using WeatherForecast.Api.Controllers.Abstract;
using WeatherForecast.Api.Resources.Filters;
using WeatherForecast.Api.Resources.Responses;
using WeatherForecast.Core.Services.Contracts;

namespace WeatherForecast.Api.Controllers
{
    public sealed class WeatherForecastsController
        : EntityController<
            WeatherForecastsController,
            Domain.Models.WeatherForecast,
            WeatherForecastResponse,
            WeatherForecastFilter>
    {
        public WeatherForecastsController(
            ILogger<WeatherForecastsController> logger,
            IPagedService<Domain.Models.WeatherForecast, WeatherForecastResponse> service)
            : base(logger, service)
        {
        }
    }
}
