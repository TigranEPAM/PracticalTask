using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PracticalTask2.Pages
{
    public class HomePage(IWebDriver driver) : BasePage(driver)
    {
        private static readonly By careersButton = By.LinkText("Careers");
        private static readonly By magnifierIcon = By.CssSelector("button.header-search__button.header__icon");
        private static readonly By searchInput = By.Id("new_form_search");
        private static readonly By searchPanel = By.ClassName("header-search__panel");
        private static readonly By findButtonLocator = By.XPath(".//*[@class='search-results__input-holder']/following-sibling::button");

        public void ClickCareers()
        {
            ClickElement(careersButton);
        }

        public void Search(string phrase)
        {
            ClickElement(magnifierIcon);

            var panelElement = WaitForElement(searchPanel);

            var input = WaitForElement(searchInput);
            input.Clear();
            input.SendKeys(phrase);

            var findButton = panelElement.FindElement(findButtonLocator);
            findButton.Click();
        }
    }
}
