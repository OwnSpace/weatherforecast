using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.DataAccess.Contexts;

namespace WeatherForecast.Api.Config
{
    public static class DbConfig
    {
        public static IServiceCollection AddDb(this IServiceCollection services, string connectionString, bool isDevelopment) =>
            services.AddDbContextPool<DataContext>(b => b.UseMySql(connectionString).EnableSensitiveDataLogging(isDevelopment));
    }
}
