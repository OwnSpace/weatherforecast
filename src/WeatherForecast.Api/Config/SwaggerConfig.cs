using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WeatherForecast.Api.Tools.Filters;

namespace WeatherForecast.Api.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string version, IConfigurationSection config)
        {
            var info = new OpenApiInfo { Version = version };
            config.Bind(info);
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc(version, info);
                    c.OperationFilter<MultipleOperationsWithSameVerbFilter>();
                    c.OperationFilter<ApplySummariesOperationFilter>();
                    c.IncludeXmlComments(xmlPath);
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.Last());
                });

            return services;
        }
    }
}
