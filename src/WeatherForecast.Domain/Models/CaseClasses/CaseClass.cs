namespace WeatherForecast.Domain.Models.CaseClasses
{
    public abstract class CaseClass<TClass, TValue>
        where TClass : CaseClass<TClass, TValue>, new()
    {
        public TValue Value { get; protected set; }

        public static TClass Cast(TValue value) => new TClass { Value = value };

        public override string ToString() => Value.ToString();
    }
}
