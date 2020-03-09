using System;

using WeatherForecast.Core.Responses;

namespace WeatherForecast.Api.Resources.Responses
{
    public sealed class CountryResponse : ApiResponse<CountryResponse>
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
