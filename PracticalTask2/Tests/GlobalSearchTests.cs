using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Pages;

namespace PracticalTask2.Tests
{
    public class GlobalSearchTests : BaseTest
    {
        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void GlobalSearch_Should_Return_Results_With_Keyword(string keyword)
        {
            HomePage homePage = new(driver);
            SearchResultsPage searchResultsPage = new(driver);
            driver.Navigate().GoToUrl("https://www.epam.com/");

            homePage.Search(keyword);
            var allLinksContainKeyword = searchResultsPage.AllLinksContainKeyword(keyword);

            allLinksContainKeyword.Should().BeTrue("All search result links should contain the keyword.");
        }
    }
}
