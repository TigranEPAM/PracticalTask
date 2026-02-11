using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Business.Pages;

namespace PracticalTask2.Tests
{
    public class GlobalSearchTests : BaseTest
    {
        [TestCase("open")]
        [TestCase("Cloud")]
        [TestCase("Support")]
        public void GlobalSearch_Should_Return_Results_With_Keyword(string keyword)
        {
            HomePage homePage = new(Driver);
            SearchResultsPage searchResultsPage = new(Driver);

            homePage.Search(keyword);
            var allLinksContainKeyword = searchResultsPage.AllLinksContainKeyword(keyword);

            allLinksContainKeyword.Should().BeTrue("All search result links should contain the keyword.");
        }
    }
}
