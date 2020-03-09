using System.Collections.Generic;

using WeatherForecast.Core.Responses;

namespace WeatherForecast.Core.Services.Contracts
{
    public interface IResponseMapper<in TEntity, out TResponse>
        where TResponse : ApiResponse<TResponse>
    {
        IEnumerable<TResponse> Map(IEnumerable<TEntity> entities);

        TResponse Map(TEntity request);
    }
}
