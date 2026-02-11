using FluentAssertions;
using OpenQA.Selenium;
using PracticalTask2.Business.Pages;
using PracticalTask2.Core.Driver;
using Reqnroll;

namespace PracticalTask2.BDD.StepDefinitions
{
    [Binding]
    public class CareersStepDefinitions(DriverContext context)
    {
        private HomePage _homePage;
        private CareersPage _careersPage;
        private JobSearchResultsPage _searchResultsPage;
        private JobDetailsPage _jobDetailsPage;
        private readonly IWebDriver _driver = context.Driver;

        [When(@"I navigate to the Careers page")]
        public void WhenINavigateToTheCareersPage()
        {
            _homePage = new HomePage(_driver);
            _homePage.ClickTopNavigationButton("Careers");
            _careersPage = new CareersPage(_driver);
        }

        [When(@"I start a job search with keyword ""(.*)""")]
        public void WhenIStartAJobSearchWithKeyword(string keyword)
        {
            _careersPage.ClickStartYourSearch();
            _searchResultsPage = new JobSearchResultsPage(_driver);
            _searchResultsPage.EnterKeyword(keyword);
        }

        [When(@"I select remote positions")]
        public void WhenISelectRemotePositions() => _searchResultsPage.SelectRemote();

        [When(@"I click search and open the latest job")]
        public void WhenIClickSearchAndOpenTheLatestJob()
        {
            _searchResultsPage.ClickSearch();
            _searchResultsPage.ClickLatestJob();
            _jobDetailsPage = new JobDetailsPage(_driver);
        }

        [Then(@"the job title should contain ""(.*)""")]
        public void ThenTheJobTitleShouldContain(string expectedKeyword) =>
            _jobDetailsPage.JobTitle.Should().Contain(expectedKeyword);
    }
}
