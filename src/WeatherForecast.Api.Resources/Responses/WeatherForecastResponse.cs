using System;

using WeatherForecast.Core.Responses;

namespace WeatherForecast.Api.Resources.Responses
{
    public sealed class WeatherForecastResponse : ApiResponse<WeatherForecastResponse>
    {
        public DateTime Date { get; set; }

        public float MinTemperatureC { get; set; }

        public float MaxTemperatureC { get; set; }

        public float MinTemperatureF => Celsius2Fahrenheit(MinTemperatureC);

        public float MaxTemperatureF => Celsius2Fahrenheit(MaxTemperatureC);

        public CityResponse City { get; set; }

        public string Summary { get; set; }

        public float Precipitation { get; set; }

        public float Wind { get; set; }

        private static float Celsius2Fahrenheit(float celsius) => 32 + (float)(celsius / 0.5556);
    }
}
