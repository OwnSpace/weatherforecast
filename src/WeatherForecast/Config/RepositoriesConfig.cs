using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.DataAccess.Repositories;
using WeatherForecast.DataAccess.Repositories.Contracts;

namespace WeatherForecast.Config
{
    public static class RepositoriesConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
        }
    }
}
