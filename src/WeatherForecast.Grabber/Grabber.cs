using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium.Chrome;
using WeatherForecast.Grabber.Pages;

namespace WeatherForecast.Grabber
{
    public static class Grabber
    {
        private static readonly ChromeOptions Options = new ChromeOptions();

        static Grabber()
        {
            Options.AddArgument("headless");
        }

        public static IEnumerable<IEnumerable<Domain.Models.WeatherForecast>> GetForecasts()
        {
            using var driver = new ChromeDriver(".", Options);
            var mainPage = new MainPage(driver);
            mainPage.Navigate();

            return mainPage.PopularCitiesNames
                .Zip(mainPage.PopularCitiesLinks)
                .Select(c => new CityPage(driver, c.First, c.Second))
                .Select(p => p.GetForecast())
                .ToArray();
        }
    }
}
