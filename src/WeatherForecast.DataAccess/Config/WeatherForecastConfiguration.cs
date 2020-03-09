using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherForecast.DataAccess.Config
{
    // ReSharper disable once UnusedType.Global
    internal sealed class WeatherForecastConfiguration : EntityConfiguration<Domain.Models.WeatherForecast>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.WeatherForecast> builder)
        {
            base.Configure(builder);

            builder.Ignore(p => p.Country);
            builder.Ignore(p => p.CityName);

            builder.Property(p => p.CityId).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.OwnsOne(
                e => e.Summary,
                b =>
                    b.Property(p => p.Value)
                     .HasColumnName(nameof(Domain.Models.WeatherForecast.Summary))
                     .IsRequired());
            builder.OwnsOne(
                e => e.MinTemperature,
                b =>
                    b.Property(p => p.Value)
                     .HasColumnName(nameof(Domain.Models.WeatherForecast.MinTemperature))
                     .IsRequired());
            builder.OwnsOne(
                e => e.MaxTemperature,
                b =>
                    b.Property(p => p.Value)
                     .HasColumnName(nameof(Domain.Models.WeatherForecast.MaxTemperature))
                     .IsRequired());
            builder.OwnsOne(
                e => e.Precipitation,
                b =>
                    b.Property(p => p.Value)
                     .HasColumnName(nameof(Domain.Models.WeatherForecast.Precipitation))
                     .IsRequired());
            builder.OwnsOne(
                e => e.Wind,
                b =>
                    b.Property(p => p.Value)
                     .HasColumnName(nameof(Domain.Models.WeatherForecast.Wind))
                     .IsRequired());
        }
    }
}
