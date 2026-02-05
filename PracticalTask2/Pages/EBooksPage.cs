using OpenQA.Selenium;

namespace PracticalTask2.Pages
{
    public class EBooksPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By header = By.CssSelector("h1 span span");

        public bool IsPageLoaded()
        {
            var headerElement = WaitForElement(header);
            return headerElement.Displayed;
        }

        public bool ValidateTitle(string title)
        {
            var titleText = GetElementText(header);
            return titleText.Equals(title);
        }
    }
}
