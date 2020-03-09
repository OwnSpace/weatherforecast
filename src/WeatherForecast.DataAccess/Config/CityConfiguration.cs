using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.DataAccess.Config
{
    // ReSharper disable once UnusedType.Global
    internal sealed class CityConfiguration : GeoEntityConfiguration<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.IATA).IsRequired(false);

            builder
                .HasOne(p => p.Country)
                .WithMany(p => p.Cities)
                .HasForeignKey(p => p.CountryId);
        }
    }
}
