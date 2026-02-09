using OpenQA.Selenium;

namespace PracticalTask2.Core.Utilities
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            screenshot.SaveAsFile($"Screenshots/{fileName}");
        }
    }
}
