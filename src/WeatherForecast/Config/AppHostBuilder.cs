using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using WeatherForecast.Services;
using WeatherForecast.Settings;

namespace WeatherForecast.Config
{
    public static class AppHostBuilder
    {
        public static IHostBuilder CreateBuilder(string[] args)
        {
            return
                new HostBuilder()
                    .ConfigureLogging(
                        (hostingContext, logging) =>
                            logging
                                .ClearProviders()
                                .AddConfiguration(hostingContext.Configuration.GetSection("Logging"))
                                .AddNLog()
                                .AddConsole()
                                .AddEventLog()
                                .AddEventSourceLogger())
                    .ConfigureHostConfiguration(
                        cfg =>
                        {
                            cfg.AddEnvironmentVariables();

                            if (args != null)
                            {
                                cfg.AddCommandLine(args);
                            }
                        })
                    .ConfigureAppConfiguration(
                        (hostingContext, builder) =>
                            builder
                                .SetBasePath(AppContext.BaseDirectory)
                                .AddJsonFile("appsettings.json", false, true)
                                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                                .AddEnvironmentVariables())
                    .ConfigureServices(
                        (hostingContext, services) =>
                        {
                            var connectionString = hostingContext.Configuration.GetConnectionString("DefaultConnection");
                            var dev = hostingContext.HostingEnvironment.IsDevelopment();

                            services
                                .AddDb(connectionString, dev)
                                .AddRepositories()
                                .AddLogging(b => b.AddNLog())
                                .Configure<JobSettings>(hostingContext.Configuration.GetSection("Job"))
                                .AddHostedService<GrabberService>();
                        })

                    // UseSystemd() // Linux
                    .UseWindowsService();
        }
    }
}
