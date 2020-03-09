namespace WeatherForecast.Core.Responses
{
    public abstract class ApiResponse<TResponse>
        where TResponse : ApiResponse<TResponse>
    {
    }
}
