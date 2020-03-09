using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;

namespace WeatherForecast.Grabber.Pages
{
    public sealed class MainPage : Page
    {
        private IEnumerable<IWebElement> popularCities;

        public MainPage(IWebDriver driver)
            : base(driver)
        {
        }

        public IEnumerable<string> PopularCitiesLinks => PopularCities.Select(it => it.GetAttribute("href")).ToArray();

        public IEnumerable<string> PopularCitiesNames => PopularCities.Select(it => it.FindElement(By.ClassName("cities_name")).Text).ToArray();

        protected override string URI { get; } = "https://www.gismeteo.ru/";

        private IWebElement PopularCitiesSection => Driver.FindElement(By.ClassName("js_cities_pcities"));

        private IWebElement PopularCitiesContainer => PopularCitiesSection.FindElement(By.ClassName("cities_list"));

        private IEnumerable<IWebElement> PopularCities => popularCities ??= PopularCitiesContainer.FindElements(By.CssSelector("div.cities_item>a.cities_link"));
    }
}
