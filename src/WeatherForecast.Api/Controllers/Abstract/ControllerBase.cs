using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Filters;
using WeatherForecast.Core.Responses;
using WeatherForecast.Core.Services.Contracts;

namespace WeatherForecast.Api.Controllers.Abstract
{
    /// <inheritdoc/>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ControllerBase<TController, TEntity, TResponse>
        : LoggableController<TController>
        where TController : ControllerBase
        where TEntity : Entity
        where TResponse : ApiResponse<TResponse>
    {
        protected ControllerBase(ILogger<TController> logger)
            : base(logger)
        {
        }

        protected IPagedService<TEntity, TResponse> PagedService { get; set; }

        private string CurrentEntityLogicalName { get; } = typeof(TEntity).Name;

        protected async Task<IActionResult> GetAsync<TPagingFilter>(TPagingFilter queryExpression)
            where TPagingFilter : AbstractPagingFilter<TEntity>
        {
            Logger.LogInformation($"List of {CurrentEntityLogicalName} requested");

            var response = await PagedService.GetPagedAsync(queryExpression);

            return Ok(response);
        }
    }
}
