using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Core.Domain;
using WeatherForecast.Domain.Models.Abstract;

namespace WeatherForecast.DataAccess.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity> HasLifetime<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, ILifetime =>
                builder.OwnsOne(
                    e => e.Lifetime,
                    b =>
                    {
                        b.Property(p => p.CreatedAt).HasColumnName("CreatedAt").IsRequired();
                        b.Property(p => p.ModifiedAt).HasColumnName("ModifiedAt").IsRequired();
                        b.Property(p => p.DeletedAt).HasColumnName("DeletedAt").IsRequired(false);
                    });

        public static EntityTypeBuilder<TEntity> HasGeoPoint<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : GeoEntity =>
                builder.OwnsOne(
                    e => e.GeoPoint,
                    b =>
                    {
                        b.Property(p => p.Lat).HasColumnName("GeoPointLat").IsRequired();
                        b.Property(p => p.Lng).HasColumnName("GeoPointLng").IsRequired();
                    });
    }
}
