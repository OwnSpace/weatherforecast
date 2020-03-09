using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeatherForecast.Api.Controllers.Abstract
{
    /// <inheritdoc/>
    [ApiController]
    public abstract class LoggableController<TController> : ControllerBase
        where TController : ControllerBase
    {
        protected LoggableController(ILogger<TController> logger) => Logger = logger;

        protected ILogger<TController> Logger { get; }
    }
}
