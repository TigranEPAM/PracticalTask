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

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

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
