using System;

namespace WeatherForecast.Extensions
{
    public class ColoredConsole : IDisposable
    {
        private ColoredConsole(ConsoleColor color) => Console.ForegroundColor = color;

        public static ColoredConsole WithColor(ConsoleColor color) => new ColoredConsole(color);

        public void Dispose()
        {
            Console.ResetColor();
        }
    }
}
