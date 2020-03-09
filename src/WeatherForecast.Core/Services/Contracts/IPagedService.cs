using System.Threading.Tasks;

using WeatherForecast.Core.Domain;
using WeatherForecast.Core.Filters;
using WeatherForecast.Core.Paging;
using WeatherForecast.Core.Responses;

namespace WeatherForecast.Core.Services.Contracts
{
    public interface IPagedService<TEntity, TResponse>
        where TEntity : Entity
        where TResponse : ApiResponse<TResponse>
    {
        Task<PagedResponse<TResponse>> GetPagedAsync(AbstractPagingFilter<TEntity> queryExpression);
    }
}
