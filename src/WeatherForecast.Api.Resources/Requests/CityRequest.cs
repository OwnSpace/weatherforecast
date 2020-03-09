using WeatherForecast.Core.Requests;

namespace WeatherForecast.Api.Resources.Requests
{
    public sealed class CityRequest : ApiRequest<CityRequest>
    {
        public string IATA { get; set; }

        public string Name { get; set; }
    }
}
