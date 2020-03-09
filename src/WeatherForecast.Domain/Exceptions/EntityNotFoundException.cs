using System;

using WeatherForecast.Core.Domain;

namespace WeatherForecast.Domain.Exceptions
{
    public class EntityNotFoundException<TEntity> : Exception
        where TEntity : Entity
    {
        public EntityNotFoundException()
            : base($"Entity of type {typeof(TEntity).Name} not found")
        {
        }

        public EntityNotFoundException(string key)
            : base($"Entity of type {typeof(TEntity).Name} not found by key {key}")
        {
        }
    }
}
