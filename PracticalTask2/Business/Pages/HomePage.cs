using OpenQA.Selenium;

namespace PracticalTask2.Business.Pages
{
    public class HomePage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By magnifierIcon = By.CssSelector("button.header-search__button.header__icon");
        private readonly By searchInput = By.Id("new_form_search");
        private readonly By searchPanel = By.ClassName("header-search__panel");
        private readonly By findButtonLocator =
            By.XPath(".//*[@class='search-results__input-holder']/following-sibling::button");
        private By TopNavigationButton(string buttonText) =>
            By.XPath($"//nav[@class='top-navigation-ui-23']//span/a[text()='{buttonText}']");
        private By FlyoutMenu(string buttonText) =>
            By.XPath($"//li[.//a[normalize-space()='{buttonText}']]//div[contains(@class,'top-navigation__flyout')]");
        private By SubMenuItem(string text) =>
            By.XPath($"//a[contains(@class,'top-navigation__sub-link') and normalize-space()='{text}']");


        public void ClickTopNavigationButton(string buttonText)
        {
            var locator = TopNavigationButton(buttonText);
            WaitForElementToBeClickable(locator);
            ClickElement(locator);
        }

        public void HoverTopNavigationButton(string buttonText)
        {
            var locator = TopNavigationButton(buttonText);
            WaitForElementToBeClickable(locator);
            Hover(locator);
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

        public void ClickSubMenuItem(string subMenuText)
        {
            var element = WaitForElement(SubMenuItem(subMenuText));
            element.Click();
        }

        public bool IsSubMenuVisible(string subMenuText)
        {
            var element = WaitForElement(SubMenuItem(subMenuText));
            return element.Displayed;
        }
    }
}
