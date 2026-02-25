using Microsoft.VisualStudio.CodeCoverage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace PracticalTask2.Core.Driver
{
    public static class BrowserFactory
    {
        private static readonly string downloadFolder = Path.Combine(Path.GetTempPath(), "EPAMDownloads");

        public static IWebDriver CreateDriver(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(GetChromeOptions()),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Edge => new EdgeDriver(GetEdgeOptions()),
                _ => throw new ArgumentException("Unsupported browser")
            };
        }

        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", downloadFolder);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            return options;
        }

        private static EdgeOptions GetEdgeOptions()
        {
            var options = new EdgeOptions();
            options.AddUserProfilePreference("download.default_directory", downloadFolder);
            options.AddArgument("--start-maximized");
            return options;
        }
    }
}
