using OpenQA.Selenium;
using PracticalTask2.Core.Driver;
using Reqnroll;

namespace PracticalTask2.BDD.StepDefinitions
{
    [Binding]
    public class SharedStepDefinitions(DriverContext context)
    {
        private readonly IWebDriver _driver = context.Driver;

        [Given(@"I am on the EPAM home page")]
        public void GivenIAmOnTheEPAMHomePage() => _driver.Navigate().GoToUrl(PracticalTask2.Core.Configuration.FrameworkConfig.BaseUrl);

    }
}
