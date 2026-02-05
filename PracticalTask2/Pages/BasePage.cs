using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTask2.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;
        private const int DefaultTimeoutSeconds = 15;

        protected BasePage(IWebDriver driver, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        }

        protected IWebElement WaitForElement(By locator)
        {
            return Wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        protected IWebElement WaitForElementToBeClickable(By locator)
        {
            return Wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return (element.Displayed && element.Enabled) ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        protected void ClickElement(By locator)
        {
            var element = WaitForElementToBeClickable(locator);
            element.Click();
        }

        protected void ScrollIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        protected void ScrollIntoViewAndClick(By locator)
        {
            var element = Driver.FindElement(locator);
            ((IJavaScriptExecutor)Driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }

        protected string GetElementText(By locator)
        {
            return WaitForElement(locator).Text;
        }
    }
}
