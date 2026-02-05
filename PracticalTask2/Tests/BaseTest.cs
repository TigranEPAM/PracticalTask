using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PracticalTask2.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        string downloadFolder = Path.Combine(Path.GetTempPath(), "EPAMDownloads");

        [SetUp]
        public void Setup()
        {
            bool runHeadless = TestContext.Parameters.Get("headless", "false") == "true";

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            if (runHeadless)
            {
                options.AddArgument("--headless");
                options.AddArgument("--window-size=1920,1080");
            }
            options.AddUserProfilePreference("download.default_directory", downloadFolder);
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Navigate().GoToUrl("https://www.epam.com/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
