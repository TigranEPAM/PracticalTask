using FluentAssertions;
using OpenQA.Selenium;
using PracticalTask2.Business.Pages;
using PracticalTask2.Core.Driver;
using Reqnroll;

namespace PracticalTask2.BDD.StepDefinitions
{
    [Binding]
    public class GlobalSearchStepDefinitions(DriverContext context)
    {
        private HomePage _homePage;
        private SearchResultsPage _searchResultsPage;

        private readonly IWebDriver _driver = context.Driver;

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string keyword)
        {
            _homePage = new HomePage(_driver);
            _homePage.Search(keyword);
            _searchResultsPage = new SearchResultsPage(_driver);
        }

        [Then(@"all search results links should contain ""(.*)""")]
        public void ThenAllSearchResultsLinksShouldContain(string keyword) =>
            _searchResultsPage.AllLinksContainKeyword(keyword).Should().BeTrue();
    }
}
