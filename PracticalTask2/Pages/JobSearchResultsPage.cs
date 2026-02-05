using OpenQA.Selenium;

namespace PracticalTask2.Pages
{
    public class JobSearchResultsPage(IWebDriver driver) : BasePage(driver)
    {
        private By KeywordInputLocator => By.Name("search");
        private By RemoteCheckboxLocator => By.XPath("//div[@class='List_sideMenu__wGtLn']//input[@name='vacancy_type-Remote']");
        private By SearchButtonLocator => By.ClassName("SearchBox_button__3ImF7");
        private By LatestJobCardLocator => By.XPath("//div[@class='JobCard_panel__gTD7e'][last()]//a");

        public void EnterKeyword(string keyword)
        {
            var input = WaitForElement(KeywordInputLocator);
            input.Clear();
            input.SendKeys(keyword);
        }

        public void SelectRemote()
        {
            ScrollIntoViewAndClick(RemoteCheckboxLocator);
        }

        public void ClickSearch()
        {
            ClickElement(SearchButtonLocator);
        }

        public void ClickLatestJob()
        {
            var latestJob = WaitForElement(LatestJobCardLocator);
            ScrollIntoView(latestJob);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", latestJob);
        }
    }
}
