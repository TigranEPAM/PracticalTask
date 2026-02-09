using OpenQA.Selenium;
using PracticalTask2.Business.Pages;
using Serilog;

namespace PracticalTask2.Business.Workflows
{
    public class JobSearchWorkflow
    {
        private readonly HomePage _home;
        private readonly CareersPage _careers;
        private readonly JobSearchResultsPage _results;
        private readonly JobDetailsPage _details;

        public JobSearchWorkflow(IWebDriver driver)
        {
            _home = new HomePage(driver);
            _careers = new CareersPage(driver);
            _results = new JobSearchResultsPage(driver);
            _details = new JobDetailsPage(driver);
        }

        public string SearchRemoteJob(string keyword)
        {
            Log.Information($"Searching for remote job: {keyword}");

            _home.ClickTopNavigationButton("Careers");
            _careers.ClickStartYourSearch();
            _results.EnterKeyword(keyword);
            _results.SelectRemote();
            _results.ClickSearch();
            _results.ClickLatestJob();

            return _details.JobTitle;
        }
    }
}
