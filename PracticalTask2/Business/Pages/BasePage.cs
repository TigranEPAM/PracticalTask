using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PracticalTask2.Business.Pages
{
    public abstract class BasePage(IWebDriver driver, int timeoutSeconds = BasePage.DefaultTimeoutSeconds)
    {
        protected readonly IWebDriver Driver = driver;
        protected readonly WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        private const int DefaultTimeoutSeconds = 15;

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
        protected IReadOnlyCollection<IWebElement> WaitForElements(By locator)
        {
            return Wait.Until(driver =>
            {
                try
                {
                    var elements = driver.FindElements(locator);
                    return elements.Any(e => e.Displayed) ? elements.Where(e => e.Displayed).ToList() : null;
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

        protected void Hover(By locator)
        {
            var element = WaitForElement(locator);
            Actions actions = new(Driver);
            actions.MoveToElement(element).Perform();
        }

        protected void ScrollIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        protected void ScrollIntoView(By locator)
        {
            var element = WaitForElement(locator);
            Actions actions = new(Driver);
            actions.MoveToElement(element).Perform();
        }

        protected void ScrollIntoViewAndClick(By locator)
        {
            var element = Driver.FindElement(locator);
            ((IJavaScriptExecutor)Driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }

        protected void ScrollIntoViewAndClickFirst(By locator)
        {
            var element = Driver.FindElements(locator).FirstOrDefault();
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
