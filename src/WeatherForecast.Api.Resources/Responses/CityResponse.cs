using System;

using WeatherForecast.Core.Responses;

namespace WeatherForecast.Api.Resources.Responses
{
    public sealed class CityResponse : ApiResponse<CityResponse>
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public CountryResponse Country { get; set; }
    }
}
