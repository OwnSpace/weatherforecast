using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherForecast.Api.Config;
using WeatherForecast.Api.Extensions;
using WeatherForecast.Api.Tools;

namespace WeatherForecast.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Version = Configuration.GetValue<string>("Version");
            Env = env;
        }

        private IConfiguration Configuration { get; }

        private string Version { get; }

        private IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services
                .AddDb(connectionString, Env.IsDevelopment())
                .AddRepositories()
                .AddAutoMapper(GetType())
                .AddServices()
                .AddSwagger(Version, Configuration.GetSection("Swagger"))
                .AddMvcCore(options => options.Filters.Add(typeof(ValidateModelStateAttribute)))
                .AddApiExplorer()
                .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<IValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                   .UseExceptionHandler("/Error")
                   .UseHsts();
            }

            app.UseSwagger()
               .UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{Version}/swagger.json", $"WeatherForecast API {Version.ToUpper()}"))
               .UseOwin();

            app.UseVersionMiddleware(Version)
               .UseHttpsRedirection()
               .UseRouting()
               .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
