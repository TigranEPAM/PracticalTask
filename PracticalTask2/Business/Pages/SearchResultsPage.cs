using OpenQA.Selenium;

namespace PracticalTask2.Business.Pages
{
    public class SearchResultsPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By searchResultLinks = By.CssSelector("a.search-results__title-link");

        public bool AllLinksContainKeyword(string keyword)
        {
            var searchResultsLink = WaitForElements(searchResultLinks);
            return searchResultsLink
                .All(link => link.Text.ToUpper().Contains(keyword.ToUpper()));
        }
    }
}
