using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTask2.Tests
{
    public class GlobalSearchTests : BaseTest
    {
        [TestCase("BLOCKCHAIN")]
        [TestCase("Cloud")]
        [TestCase("Automation")]
        public void GlobalSearch_Should_Return_Results_With_Keyword(string keyword)
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");

            var magnifierIcon = driver.FindElement(By.CssSelector("button.header-search__button.header__icon"));
            magnifierIcon.Click();

            var searchInput = driver.FindElement(By.Id("new_form_search"));
            searchInput.Clear();
            searchInput.SendKeys(keyword);

            var findButton = driver.FindElement(By.CssSelector("button.custom-button.custom-search-button"));
            findButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElements(By.CssSelector("a.search-results__title-link")).Any());

            var searchResultLinks = driver.FindElements(By.CssSelector("a.search-results__title-link"));

            bool allLinksContainKeyword = searchResultLinks
                .All(link => link.Text.ToUpper().Contains(keyword.ToUpper()));

            allLinksContainKeyword.Should().BeTrue("All search result links should contain the keyword.");
        }
    }
}
