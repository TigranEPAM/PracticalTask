using FluentAssertions;
using OpenQA.Selenium;
using PracticalTask2.Business.Pages;
using PracticalTask2.Core.Driver;
using Reqnroll;

namespace PracticalTask2.BDD.StepDefinitions
{
    [Binding]
    public class DownloadStepDefinitions(DriverContext context)
    {
        private HomePage _homePage;
        private AboutPage _aboutPage;
        private readonly string _downloadFolder = Path.Combine(Path.GetTempPath(), "EPAMDownloads");
        private readonly IWebDriver _driver = context.Driver;

        [When(@"I navigate to the About page")]
        public void WhenINavigateToTheAboutPage()
        {
            _homePage = new HomePage(_driver);
            _homePage.ClickTopNavigationButton("About");
            _aboutPage = new AboutPage(_driver);
            _aboutPage.PageIsLoaded();
            _aboutPage.ScrollBannerIntoView();
        }

        [When(@"I click on the EPAM at a Glance banner download button")]
        public void WhenIClickOnTheDownloadButton() => _aboutPage.ClickDownloadButton();

        [Then(@"the file ""(.*)"" should be downloaded successfully")]
        public void ThenTheFileShouldBeDownloadedSuccessfully(string fileName)
        {
            string filePath = Path.Combine(_downloadFolder, fileName);
            int waited = 0, timeout = 15000;

            while (!File.Exists(filePath) && waited < timeout)
            {
                Thread.Sleep(500);
                waited += 500;
            }

            File.Exists(filePath).Should().BeTrue("The PDF file should have been downloaded.");
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }
}
