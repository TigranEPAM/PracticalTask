using OpenQA.Selenium;

namespace PracticalTask2.Business.Pages
{
    public class InsightsPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By sliderRightButton = By.CssSelector("button.slider__right-arrow.slider-navigation-arrow");
        private readonly By targetSlide = By.XPath("//div[@class='owl-item active']//span[text()=': Turning Theory into Action']");
        private readonly By readMoreButton = By.XPath("//a[@href='https://www.epam.com/insights/ebook/evolving-into-agentic-ai-turning-theory-into-action']");

        public void NavigateToReadMoreLinkOnThirdTab()
        {
            WaitForElement(sliderRightButton);
            ScrollIntoViewAndClickFirst(sliderRightButton);
            ScrollIntoViewAndClickFirst(sliderRightButton);
            WaitForElement(targetSlide);
            ScrollIntoViewAndClickFirst(readMoreButton);
        }
    }
}
