using WeatherForecast.Core.Requests;

namespace WeatherForecast.Core.Services.Contracts
{
    public interface IService<in TRequest, TResponse>
        where TRequest : ApiRequest<TRequest>
    {
    }
}
