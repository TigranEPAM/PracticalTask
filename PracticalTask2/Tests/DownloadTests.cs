using FluentAssertions;
using NUnit.Framework;
using PracticalTask2.Business.Pages;

namespace PracticalTask2.Tests
{
    public class DownloadTests : BaseTest
    {
        [Category("UI")]
        [TestCase("EPAM_Corporate_Overview_Sept_25.pdf")]
        public void ValidateDownloadFile(string fileName)
        {
            HomePage homePage = new(Driver);
            AboutPage aboutPage = new(Driver);

            string downloadFolder = Path.Combine(Path.GetTempPath(), "EPAMDownloads");
            homePage.ClickTopNavigationButton("About");
            aboutPage.PageIsLoaded();
            aboutPage.ScrollBannerIntoView();
            aboutPage.ClickDownloadButton();

            string downloadedFilePath = Path.Combine(downloadFolder, fileName);

            int timeoutSeconds = 15;
            int waited = 0;

            while (!File.Exists(downloadedFilePath) && waited < timeoutSeconds * 1000)
            {
                Thread.Sleep(500);
                waited += 500;
            }

            File.Exists(downloadedFilePath).Should().BeTrue("The PDF file should have been downloaded.");

            if (File.Exists(downloadedFilePath))
                File.Delete(downloadedFilePath);
        }
    }
}
