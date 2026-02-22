using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using PracticalTask2.Core.Configuration;

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
                BrowserType.Edge => new EdgeDriver(),
                _ => throw new ArgumentException("Unsupported browser")
            };
        }

        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", downloadFolder);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddArgument("--start-maximized");
            if (FrameworkConfig.Headless)
                options.AddArgument("--headless=new");
            return options;
        }
    }
}
