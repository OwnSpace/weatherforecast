using System;

using WeatherForecast.Core.Requests;

namespace WeatherForecast.Api.Resources.Requests
{
    public sealed class WeatherForecastRequest : ApiRequest<WeatherForecastRequest>
    {
        public string City { get; set; }

        public DateTime Date { get; set; }
    }
}
