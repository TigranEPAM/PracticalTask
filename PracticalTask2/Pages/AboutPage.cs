using OpenQA.Selenium;

namespace PracticalTask2.Pages
{
    public class AboutPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By HeaderSelector = By.XPath("//h1[.//span[text()='About']]");
        private readonly By epamAtGlanceBanner = 
            By.XPath("//span/span[contains(., 'EPAM at') and contains(., 'a Glance')]");
        private readonly By downloadButton = By.CssSelector("div.button div.button__wrapper.button--left a");

        public bool PageIsLoaded()
        {
            var headerElement = WaitForElement(HeaderSelector);
            return headerElement.Displayed;
        }

        public void ClickDownloadButton()
        {
            ScrollIntoViewAndClick(downloadButton);
        }

        public void ScrollBannerIntoView()
        {
            ScrollIntoView(epamAtGlanceBanner);
        }

        public string GetDownloadLink()
        {
            var button = WaitForElementToBeClickable(downloadButton);
            return button.GetAttribute("href");
        }
    }
}
