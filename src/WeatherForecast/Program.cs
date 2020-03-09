using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using NLog;
using Polly;
using Polly.Retry;
using WeatherForecast.Config;
using WeatherForecast.Extensions;

namespace WeatherForecast
{
    public static class Program
    {
        private const int StartRetryCount = 3;

        private static readonly AsyncRetryPolicy StartPolicy =
            Policy
                .Handle<Exception>()
                .RetryAsync(
                    StartRetryCount,
                    (ex, retryCount) =>
                    {
                        if (retryCount < StartRetryCount)
                        {
                            LogException(ex);
                            return;
                        }

                        LogException(ex, "Service stopped 'cause of exception");
                        LogManager.Shutdown();
                    });

        private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();

        public static async Task Main(string[] args) => await StartPolicy.ExecuteAsync(() => AppHostBuilder.CreateBuilder(args).RunConsoleAsync());

        private static void LogException(Exception ex, string message = "")
        {
            using (ColoredConsole.WithColor(ConsoleColor.Red))
            {
                Logger.Error(ex, message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
