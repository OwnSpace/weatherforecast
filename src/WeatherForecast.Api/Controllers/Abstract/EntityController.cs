using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Filters;
using WeatherForecast.Core.Responses;
using WeatherForecast.Core.Services.Contracts;

namespace WeatherForecast.Api.Controllers.Abstract
{
    public class EntityController<TController, TEntity, TResponse, TPagingFilter>
        : ControllerBase<TController, TEntity, TResponse>
        where TController : ControllerBase
        where TEntity : Entity
        where TResponse : ApiResponse<TResponse>
        where TPagingFilter : AbstractPagingFilter<TEntity>
    {
        public EntityController(
            ILogger<TController> logger,
            IPagedService<TEntity, TResponse> service)
            : base(logger)
        {
            PagedService = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromBody]TPagingFilter queryExpression) => await GetAsync(queryExpression);
    }
}
