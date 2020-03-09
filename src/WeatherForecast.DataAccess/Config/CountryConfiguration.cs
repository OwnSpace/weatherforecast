using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Domain.Models.Geo;

namespace WeatherForecast.DataAccess.Config
{
    // ReSharper disable once UnusedType.Global
    internal sealed class CountryConfiguration : GeoEntityConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Code).IsRequired();
        }
    }
}
