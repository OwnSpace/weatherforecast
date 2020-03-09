using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Api.Services;
using WeatherForecast.Core.Services;
using WeatherForecast.Core.Services.Contracts;

namespace WeatherForecast.Api.Config
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services
                .AddScoped(typeof(ApiMapperBase<,>), typeof(RequestMapper<,>))
                .AddScoped(typeof(ApiMapperBase<,>), typeof(ResponseMapper<,>))
                .AddScoped(typeof(IPagedService<,>), typeof(EntityService<,>));
    }
}
