using FluentAssertions;
using OpenQA.Selenium;
using PracticalTask2.Business.Pages;
using PracticalTask2.Core.Driver;
using Reqnroll;

namespace PracticalTask2.BDD.StepDefinitions
{
    [Binding]
    public class InsightsStepDefinitions(DriverContext context)
    {
        private HomePage _homePage;
        private InsightsPage _insightsPage;
        private EBooksPage _eBooksPage;
        private readonly IWebDriver _driver = context.Driver;

        [When(@"I navigate to the Insights page")]
        public void WhenINavigateToTheInsightsPage()
        {
            _homePage = new HomePage(_driver);
            _homePage.ClickTopNavigationButton("Insights");
            _insightsPage = new InsightsPage(_driver);
        }

        [When(@"I click the ""Read More"" link on the third tab")]
        public void WhenIClickTheReadMoreLinkOnThirdTab() => _insightsPage.NavigateToReadMoreLinkOnThirdTab();

        [Then(@"the e-book page should be loaded")]
        public void ThenTheEBookPageShouldBeLoaded()
        {
            _eBooksPage = new EBooksPage(_driver);
            _eBooksPage.IsPageLoaded().Should().BeTrue();
        }

        [Then(@"the title should be ""(.*)""")]
        public void ThenTheTitleShouldBe(string expectedTitle) =>
            _eBooksPage.ValidateTitle(expectedTitle).Should().BeTrue();
    }
}
