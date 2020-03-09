namespace WeatherForecast.Api.Resources.Responses
{
    public class Response<T> : ResponseBase
    {
        private Response(T value, string message = default)
            : base(message)
        {
            Value = value;
        }

        public T Value { get; }

        public static implicit operator Response<T>(T value) => SuccessResponse(value);

        public static implicit operator Response<T>(string msg) => FailResponse(msg);

        public static Response<T> FailResponse(string msg) => new Fail(msg);

        public static Response<T> SuccessResponse(T value) => new Success(value);

        public sealed class Success : Response<T>
        {
            public Success(T value)
                : base(value, string.Empty)
            {
            }

            public static implicit operator Success(T value) => new Success(value);
        }

        public sealed class Fail : Response<T>
        {
            public Fail(string message)
                : base(default, message)
            {
            }

            public static implicit operator Fail(string msg) => new Fail(msg);
        }
    }
}
