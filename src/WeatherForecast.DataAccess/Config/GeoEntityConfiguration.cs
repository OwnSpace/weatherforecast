using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.DataAccess.Extensions;
using WeatherForecast.Domain.Models.Abstract;

namespace WeatherForecast.DataAccess.Config
{
    internal abstract class GeoEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
        where TEntity : GeoEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.HasGeoPoint();
        }
    }
}
