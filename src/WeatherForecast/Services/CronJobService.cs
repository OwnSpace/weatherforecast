using System;
using System.Threading;
using System.Threading.Tasks;

using Cronos;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WeatherForecast.Services
{
    public abstract class CronJobService : BackgroundService
    {
        protected CronJobService(ILogger logger, string cron)
        {
            Logger = logger;
            CronExpression = CronExpression.Parse(cron);
        }

        protected ILogger Logger { get; }

        private CronExpression CronExpression { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ExecuteJobAsync();

                var nextOccurence = GetNextOccurrence();
                if (nextOccurence == default)
                {
                    Logger.LogInformation("Service stopped by schedule");
                    break;
                }

                await Task.Delay(nextOccurence.Value, stoppingToken);
            }
        }

        protected abstract Task ExecuteJobAsync();

        private TimeSpan? GetNextOccurrence()
        {
            var next = CronExpression.GetNextOccurrence(DateTimeOffset.UtcNow, TimeZoneInfo.Utc);
            if (next.HasValue)
            {
                return next.Value - DateTimeOffset.UtcNow;
            }

            return default;
        }
    }
}
