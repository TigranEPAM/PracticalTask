using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Pages;

namespace PracticalTask2.Tests
{
    public class InsightsTests : BaseTest
    {
        [TestCase("Evolving into Agentic AI: Turning Theory into Action")]
        public async Task ValidateTitleOfTheArticle(string expectedText)
        {
            HomePage homePage = new(driver);
            InsightsPage insightsPage = new(driver);
            EBooksPage eBooksPage = new(driver);
            driver.Navigate().GoToUrl("https://www.epam.com/");

            homePage.ClickTopNavigationButton("Insights");
            insightsPage.NavigateToReadMoreLinkOnThirdTab();
            eBooksPage.IsPageLoaded().Should().BeTrue();
            eBooksPage.ValidateTitle(expectedText);
        }
    }
}
