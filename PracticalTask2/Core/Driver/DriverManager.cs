using OpenQA.Selenium;
using PracticalTask2.Core.Configuration;

namespace PracticalTask2.Core.Driver
{
    public sealed class DriverManager
    {
        private static IWebDriver? _driver;

        public static IWebDriver Driver =>
            _driver ??= BrowserFactory.CreateDriver(FrameworkConfig.Browser);

        public static void Quit()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
