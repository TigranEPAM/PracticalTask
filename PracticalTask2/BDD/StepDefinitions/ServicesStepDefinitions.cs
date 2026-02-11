using FluentAssertions;
using OpenQA.Selenium;
using PracticalTask2.Business.Pages;
using PracticalTask2.Core.Driver;
using Reqnroll;

namespace PracticalTask2.BDD.StepDefinitions
{
    [Binding]
    public class ServicesStepDefinitions(DriverContext context)
    {
        private HomePage _homePage;
        private ServicesPage _servicesPage;
        private readonly IWebDriver _driver = context.Driver;

        [When(@"I navigate to the Services menu and select ""(.*)""")]
        public void WhenINavigateToTheServicesMenuAndSelect(string category)
        {
            _homePage = new HomePage(_driver);
            _homePage.HoverTopNavigationButton("Services");
            _homePage.IsSubMenuVisible(category);
            _homePage.ClickSubMenuItem(category);
            _servicesPage = new ServicesPage(_driver);
            _servicesPage.IsPageLoaded(category);
        }

        [Then(@"the page title should contain ""(.*)""")]
        public void ThenThePageTitleShouldContain(string category)
        {
            _servicesPage.GetTitleByText(category).Text.Should().Contain(category);
        }

        [Then(@"the 'Our Related Expertise' section should be displayed")]
        public void ThenTheOurRelatedExpertiseSectionShouldBeDisplayed()
        {
            _servicesPage.IsRelatedExpertiseVisible().Should().BeTrue();
        }
    }
}
