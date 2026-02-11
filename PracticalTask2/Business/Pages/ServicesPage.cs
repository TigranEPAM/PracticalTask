using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace PracticalTask2.Business.Pages
{
    public class ServicesPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By ourRelatedExpertiseLocator = By.XPath("//span[@class='museo-sans-light' and contains(normalize-space(), 'Our Related Expertise')]");
        private By GetHeaderSelector(string text) => By.XPath($"//div[@class='column-control']//span[text()='{text}']");

        public IWebElement GetTitleByText(string text) 
        {
            return Driver.FindElement(GetHeaderSelector(text));
        }

        public bool IsRelatedExpertiseVisible()
        {
            var element = WaitForElement(ourRelatedExpertiseLocator);
            return element.Displayed;
        }

        public bool IsPageLoaded(string title)
        {
            var headerElement = WaitForElement(GetHeaderSelector(title));
            return headerElement.Displayed;
        }
    }
}
