using OpenQA.Selenium;

namespace PracticalTask2.Pages
{
    public class HomePage(IWebDriver driver) : BasePage(driver)
    {
        private static readonly By careersButton = By.LinkText("Careers");

        public void ClickCareers()
        {
            ClickElement(careersButton);
        }
    }
}
