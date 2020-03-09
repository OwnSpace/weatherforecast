namespace WeatherForecast.Core.Domain
{
    public abstract class DbKey<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
