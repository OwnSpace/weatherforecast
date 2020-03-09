namespace WeatherForecast.Api.Resources.Responses
{
    public abstract class ResponseBase
    {
        protected ResponseBase(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
