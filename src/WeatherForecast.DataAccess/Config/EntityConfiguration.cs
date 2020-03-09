using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Core.Domain;
using WeatherForecast.DataAccess.Extensions;

namespace WeatherForecast.DataAccess.Config
{
    internal abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) => builder.HasLifetime();
    }
}
