using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WeatherForecast.Core.Domain;
using WeatherForecast.DataAccess.Extensions;

namespace WeatherForecast.DataAccess.Contexts
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class DataContext : DbContext
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;
            var editedEntities =
                    ChangeTracker
                        .Entries()
                        .Where(e => e.State == EntityState.Modified)
                        .Select(e => e.Entity)
                        .OfType<ILifetime>()
                        .ToArray();
            foreach (var entity in editedEntities)
            {
                entity.Lifetime.ModifiedAt = now;
                Entry(entity).Reference(r => r.Lifetime).TargetEntry.State = EntityState.Modified;
            }

            var createdEntities =
                ChangeTracker
                    .Entries()
                    .Where(e => e.State == EntityState.Added)
                    .Select(e => e.Entity)
                    .OfType<ILifetime>()
                    .ToArray();

            foreach (var entity in createdEntities)
            {
                entity.Lifetime.CreatedAt = now;
                entity.Lifetime.ModifiedAt = now;
                Entry(entity).Reference(r => r.Lifetime).TargetEntry.State = EntityState.Added;
            }

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override EntityEntry<T> Remove<T>(T entity)
        {
            var now = DateTime.UtcNow;
            if (entity is ILifetime lifetimeEntity && lifetimeEntity.Lifetime != default)
            {
                lifetimeEntity.Lifetime.DeletedAt = now;
            }

            var entry = Entry(entity);
            entry.State = EntityState.Modified;

            return entry;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes().ToArray();
            foreach (var relationship in entityTypes.SelectMany(t => t.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var entityType in entityTypes)
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Seed();
        }
    }
}
