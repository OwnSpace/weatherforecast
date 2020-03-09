using WeatherForecast.Core.Requests;

namespace WeatherForecast.Api.Resources.Requests
{
    public sealed class CountryRequest : ApiRequest<CountryRequest>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
