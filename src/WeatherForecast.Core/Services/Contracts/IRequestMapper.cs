using WeatherForecast.Core.Requests;

namespace WeatherForecast.Core.Services.Contracts
{
    public interface IRequestMapper<in TRequest, out TEntity>
        where TRequest : ApiRequest<TRequest>
    {
        TEntity Map(TRequest request);
    }
}
