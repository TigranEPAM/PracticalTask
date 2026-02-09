using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using PracticalTask2.Core.Configuration;
using PracticalTask2.Core.Driver;
using PracticalTask2.Core.Utilities;
using Log = PracticalTask2.Core.Utilities.Log;

namespace PracticalTask2.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = DriverManager.Driver;
            Driver.Navigate().GoToUrl(FrameworkConfig.BaseUrl);
            Log.Logger.Information("Test started");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotHelper.TakeScreenshot(Driver, TestContext.CurrentContext.Test.Name);
            }

            DriverManager.Quit();
            Log.Logger.Information("Test finished");
        }
    }
}
