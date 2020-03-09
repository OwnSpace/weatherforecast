using OpenQA.Selenium;

namespace WeatherForecast.Grabber.Pages
{
    public abstract class Page
    {
        protected Page(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebDriver Driver { get; }

        protected abstract string URI { get; }

        public void Navigate() => Driver.Navigate().GoToUrl(URI);
    }
}
