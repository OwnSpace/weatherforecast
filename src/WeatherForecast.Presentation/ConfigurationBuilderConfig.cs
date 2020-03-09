using System;

using Microsoft.Extensions.Configuration;

namespace WeatherForecast.Presentation
{
    public static class ConfigurationBuilderConfig
    {
        public static IConfiguration CreateConfig()
        {
            return
                new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
        }
    }
}
