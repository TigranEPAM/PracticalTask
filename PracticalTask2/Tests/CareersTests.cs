using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Pages;

namespace PracticalTask2.Tests
{
    public class CareersTests : BaseTest
    {
        [TestCase("SAP")]
        public void Job_Title_Should_Contain_Programming_Language(string expectedKeyword)
        {
            HomePage homePage = new(driver);
            CareersPage careersPage = new(driver);
            JobSearchResultsPage searchResultsPage = new(driver);
            JobDetailsPage jobDetailsPage = new(driver);

            homePage.ClickCareers();
            careersPage.ClickStartYourSearch();
            searchResultsPage.EnterKeyword(expectedKeyword);
            searchResultsPage.SelectRemote();
            searchResultsPage.ClickSearch();
            searchResultsPage.ClickLatestJob();
            jobDetailsPage.JobTitle.Should().Contain(expectedKeyword);
        }
    }
}
