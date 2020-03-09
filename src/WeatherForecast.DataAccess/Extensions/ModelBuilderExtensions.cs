using System;

using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var russiaId = Guid.NewGuid();
            modelBuilder
                .Entity<Country>()
                .HasData(
                    new
                    {
                        Id = russiaId,
                        Name = "Российская Федерация",
                        Code = "RU"
                    });

            var now = DateTime.UtcNow;
            modelBuilder
                .Entity<Country>()
                .OwnsOne(e => e.Lifetime)
                .HasData(
                    new
                        {
                            CountryId = russiaId,
                            CreatedAt = now,
                            ModifiedAt = now
                        });
        }
    }
}
