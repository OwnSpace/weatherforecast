using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeatherForecast.DataAccess.Repositories.Contracts;
using WeatherForecast.Domain.Models.Geo;
using WeatherForecast.Settings;

namespace WeatherForecast.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class GrabberService : CronJobService
    {
        private Country russia;

        // ReSharper disable once SuggestBaseTypeForParameter
        public GrabberService(
            ILogger<GrabberService> logger,
            IOptions<JobSettings> options,
            IEntityRepository<Domain.Models.WeatherForecast> weatherForecastRepository,
            IEntityRepository<Country> countryRepository,
            IEntityRepository<City> cityRepository)
            : base(logger, options.Value.Cron)
        {
            WeatherForecastRepository = weatherForecastRepository;
            CountryRepository = countryRepository;
            CityRepository = cityRepository;
        }

        private IEntityRepository<Domain.Models.WeatherForecast> WeatherForecastRepository { get; }

        private IEntityRepository<Country> CountryRepository { get; }

        private IEntityRepository<City> CityRepository { get; }

        private Country Russia => russia ??= CountryRepository.Query.FirstOrDefault(c => c.Code == "RU");

        protected override async Task ExecuteJobAsync()
        {
            // ToDo: Bulk
            foreach (var forecasts in Grabber.Grabber.GetForecasts())
            {
                foreach (var forecast in forecasts)
                {
                    var exist = await WeatherForecastRepository.ExistsAsync(w => w.City.Name == forecast.CityName && w.Date.Date == forecast.Date.Date);
                    if (exist)
                    {
                        await WeatherForecastRepository.SaveAsync(forecast);
                    }
                    else
                    {
                        var city = (await CityRepository.FindAsync(c => c.Name == forecast.CityName)).FirstOrDefault();
                        SetWeatherCity(forecast, city);

                        await WeatherForecastRepository.CreateAsync(forecast);
                    }
                }
            }

            // ToDO: informative log
            Logger.LogInformation("GRABBED!");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetWeatherCity(Domain.Models.WeatherForecast forecast, City city)
        {
            if (city != null)
            {
                forecast.CityId = city.Id;
            }
            else
            {
                forecast.City = new City { Name = forecast.CityName, Country = Russia };
            }
        }
    }
}
