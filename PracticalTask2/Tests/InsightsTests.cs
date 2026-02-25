using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Business.Pages;

namespace PracticalTask2.Tests
{
    public class InsightsTests : BaseTest
    {
        [Category("UI")]
        [TestCase("Evolving into Agentic AI: Turning Theory into Action")]
        public async Task ValidateTitleOfTheArticle(string expectedText)
        {
            HomePage homePage = new(Driver);
            InsightsPage insightsPage = new(Driver);
            EBooksPage eBooksPage = new(Driver);

            homePage.ClickTopNavigationButton("Insights");
            insightsPage.NavigateToReadMoreLinkOnThirdTab();
            eBooksPage.IsPageLoaded().Should().BeTrue();
            eBooksPage.ValidateTitle(expectedText);
        }
    }
}
