using System;

namespace WeatherForecast.Core.Domain
{
    public abstract class Entity : DbKey<Guid>, ILifetime
    {
        public Lifetime Lifetime { get; set; } = new Lifetime();
    }
}
