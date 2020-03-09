using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Polly;
using Polly.Retry;

namespace WeatherForecast.Presentation
{
    public static class Program
    {
        private static readonly AsyncRetryPolicy StartPolicy =
            Policy
              .Handle<Exception>()
              .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            await StartPolicy.ExecuteAsync(RunAsync);
        }

        private static async Task RunAsync()
        {
            var cities = await WeatherForecastAgent.GetCities();
            Application.Run(new MainForm(cities));
        }
    }
}
