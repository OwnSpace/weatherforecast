using System.Collections.Generic;
using System.Linq;

namespace WeatherForecast.Grabber.Extensions
{
    public static class ListExtensions
    {
        public static void Deconstruct<T>(this IList<T> list, out T head, out IList<T> tail)
        {
            head = list.Count > 0 ? list[0] : default;
            tail = list.Skip(1).ToList();
        }

        public static void Deconstruct<T>(this IList<T> list, out T head, out T second, out IList<T> tail)
        {
            head = list.Count > 0 ? list[0] : default;
            second = list.Count > 1 ? list[1] : default;
            tail = list.Skip(2).ToList();
        }
    }
}
