using System;
using System.Collections.Generic;
using System.Linq;

using Flurl;

using OpenQA.Selenium;

namespace WeatherForecast.Grabber.Pages
{
    public sealed class CityPage : Page
    {
        private const string TemperatureSelectorTemplate = ".chart__temperature > div.values > div.value > div.{0} > span.unit_temperature_c";

        private readonly string maxTemperatureSelector = string.Format(TemperatureSelectorTemplate, "maxt");

        private readonly string minTemperatureSelector = string.Format(TemperatureSelectorTemplate, "mint");

        private string[] summaries;

        private float[] maxTemperatures;

        private float[] minTemperatures;

        private float[] winds;

        private float[] precipitations;

        private IWebElement forecastWidget;

        public CityPage(IWebDriver driver, string name, string uri)
            : this(driver)
        {
            CityURI = uri;
            CityName = name;
        }

        private CityPage(IWebDriver driver)
            : base(driver)
        {
        }

        protected override string URI => Url.Combine(CityURI, "10-days");

        private IWebElement ForecastWidget => forecastWidget ??= Driver.FindElement(By.XPath("//*[@data-widget-id='forecast']"));

        private string[] Summaries =>
            summaries ??=
            FindInForecast(".widget__row_icon > .widget__item > .widget__value > span.tooltip")
                .Select(a => a.GetAttribute("data-text"))
                .ToArray();

        private float[] MaxTemperatures => maxTemperatures ??= Find(maxTemperatureSelector);

        private float[] MinTemperatures => minTemperatures ??= Find(minTemperatureSelector);

        private float[] Winds => winds ??= Find(".widget__row_wind-or-gust > .widget__item > .w_wind .unit_wind_m_s");

        private float[] Precipitations => precipitations ??= Find(".widget__row_precipitation > .widget__item > .w_prec > .w_prec__value");

        private string CityURI { get; }

        private string CityName { get; }

        public IEnumerable<Domain.Models.WeatherForecast> GetForecast()
        {
            Navigate();

            var now = DateTime.UtcNow;
            var result = new List<Domain.Models.WeatherForecast>(16);
            for (var i = 0; i < 10; ++i)
            {
                result.Add(
                    new Domain.Models.WeatherForecast
                        {
                            CityName = CityName,
                            Date = now.AddDays(i),
                            Summary = Summaries[i],
                            MinTemperature = MinTemperatures[i],
                            MaxTemperature = MaxTemperatures[i],
                            Precipitation = Precipitations[i],
                            Wind = Winds[i]
                        });
            }

            return result;
        }

        private static float ParseSpecial(IWebElement a) => float.Parse(a.Text.Trim().Replace("−", "-"));

        private float[] Find(string cssSelector) => FindInForecast(cssSelector).Select(ParseSpecial).ToArray();

        private IEnumerable<IWebElement> FindInForecast(string cssSelector) => ForecastWidget.FindElements(By.CssSelector(cssSelector));
    }
}
