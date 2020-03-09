using Microsoft.Extensions.Logging;
using WeatherForecast.Api.Controllers.Abstract;
using WeatherForecast.Api.Resources.Filters;
using WeatherForecast.Api.Resources.Responses;
using WeatherForecast.Core.Services.Contracts;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.Api.Controllers
{
    public class CitiesController
        : EntityController<
            CitiesController,
            City,
            CityResponse,
            CityFilter>
    {
        public CitiesController(
            ILogger<CitiesController> logger,
            IPagedService<City, CityResponse> service)
            : base(logger, service)
        {
        }
    }
}
