namespace WeatherForecast.Core.Requests
{
    public abstract class ApiRequest<TRequest>
        where TRequest : ApiRequest<TRequest>
    {
    }
}
