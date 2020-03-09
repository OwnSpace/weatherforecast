using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherForecast.Api.Resources.Filters;
using WeatherForecast.Api.Resources.Responses;
using WeatherForecast.Core.Paging;
using WeatherForecast.Core.Responses;

namespace WeatherForecast.Presentation
{
    public static class WeatherForecastAgent
    {
        private static readonly HttpClient Client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });

        static WeatherForecastAgent()
        {
            Client.BaseAddress = new Uri(Configuration.GetConnectionString("DefaultConnection"));
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IgnoreCertificateErrors();
        }

        private static IConfiguration Configuration { get; } = ConfigurationBuilderConfig.CreateConfig();

        public static async Task<IEnumerable<CityResponse>> GetCities()
        {
            var filterRequest = CityFilter.Empty;
            var request = BuildMessage(filterRequest, "cities");

            return await GetAsync<CityResponse>(request);
        }

        public static async Task<IEnumerable<WeatherForecastResponse>> GetWeatherForecasts(DateTime date, Guid cityId)
        {
            var filterRequest =
                new WeatherForecastFilter
                    {
                        Date = date,
                        CityId = cityId
                    };

            return await GetWeatherForecasts(filterRequest);
        }

        public static async Task<IEnumerable<WeatherForecastResponse>> GetWeatherForecasts(DateTime date, string city)
        {
            var filterRequest =
                new WeatherForecastFilter
                    {
                        Date = date,
                        City = city
                    };

            return await GetWeatherForecasts(filterRequest);
        }

        private static async Task<IEnumerable<WeatherForecastResponse>> GetWeatherForecasts(WeatherForecastFilter filterRequest)
        {
            var request = BuildMessage(filterRequest, "weatherForecasts");

            return await GetAsync<WeatherForecastResponse>(request);
        }

        [Conditional("DEBUG")]
        private static void IgnoreCertificateErrors()
        {
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
        }

        private static string Serialize<TFilterRequest>(TFilterRequest filterRequest) => JsonConvert.SerializeObject(filterRequest);

        private static HttpRequestMessage BuildMessage<TFilterRequest>(TFilterRequest filterRequest, string url)
        {
            var json = Serialize(filterRequest);

            return
                new HttpRequestMessage(HttpMethod.Get, Client.BaseAddress + url)
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };
        }

        private static async Task<IEnumerable<TResponse>> GetAsync<TResponse>(HttpRequestMessage request)
            where TResponse : ApiResponse<TResponse>
        {
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PagedResponse<TResponse>>(content).Data;
            }

            return Enumerable.Empty<TResponse>();
        }
    }
}
