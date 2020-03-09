using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WeatherForecast.DataAccess.Contexts;

namespace WeatherForecast.Config
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder
                .UseMySql(
                    connectionString,
                    optionsBuilder =>
                        optionsBuilder
                            .MigrationsHistoryTable("_MigrationHistory")
                            .MigrationsAssembly("WeatherForecast.Migrations"))
                .EnableSensitiveDataLogging();

            return new DataContext(builder.Options);
        }
    }
}
