using OpenQA.Selenium;

namespace PracticalTask2.Core.Utilities
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                var screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");

                Directory.CreateDirectory(screenshotPath);

                testName = string.Concat(testName.Split(Path.GetInvalidFileNameChars()));
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                var fullPath = Path.Combine(screenshotPath, fileName);

                screenshot.SaveAsFile(fullPath);
                Console.WriteLine($"Screenshot saved: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to take screenshot: {ex.Message}");
            }
        }
    }
}
