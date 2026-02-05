using OpenQA.Selenium;

namespace PracticalTask2.Pages
{
    public class JobDetailsPage(IWebDriver driver) : BasePage(driver)
    {
        private By JobTitleLocator => By.CssSelector("div[data-testid='job-details-banner-container'] h1");

        public string JobTitle => GetElementText(JobTitleLocator);
    }
}
