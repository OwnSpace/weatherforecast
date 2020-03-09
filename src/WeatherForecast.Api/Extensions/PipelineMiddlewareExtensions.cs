using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WeatherForecast.Api.Extensions
{
    public static class PipelineMiddlewareExtensions
    {
        public static IApplicationBuilder UseVersionMiddleware(this IApplicationBuilder app, string version) =>
            app.Map("/_version", a => a.Run(async rq => await rq.Response.WriteAsync(version)));
    }
}
