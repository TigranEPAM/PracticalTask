using OpenQA.Selenium;

namespace PracticalTask2.Business.Pages
{
    public class CareersPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By startYourSearchHereButton = By.XPath("//a[.//span[text()='Start Your Search Here']]");

        public void ClickStartYourSearch()
        {
            ClickElement(startYourSearchHereButton);
        }
    }
}
