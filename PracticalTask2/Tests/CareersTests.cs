using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Business.Pages;

namespace PracticalTask2.Tests
{
    public class CareersTests : BaseTest
    {
        [Category("UI")]
        [TestCase("SAP")]
        public void Job_Title_Should_Contain_Programming_Language(string expectedKeyword)
        {
            HomePage homePage = new(Driver);
            CareersPage careersPage = new(Driver);
            JobSearchResultsPage searchResultsPage = new(Driver);
            JobDetailsPage jobDetailsPage = new(Driver);

            homePage.ClickTopNavigationButton("Careers");
            careersPage.ClickStartYourSearch();
            searchResultsPage.EnterKeyword(expectedKeyword);
            searchResultsPage.SelectRemote();
            searchResultsPage.ClickSearch();
            searchResultsPage.ClickLatestJob();
            jobDetailsPage.JobTitle.Should().Contain(expectedKeyword);
        }
    }
}
