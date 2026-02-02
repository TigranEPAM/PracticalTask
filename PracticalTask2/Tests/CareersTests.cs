using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace PracticalTask2.Tests
{
    public class CareersTests : BaseTest
    {
        [TestCase("Engineer")]
        public void Job_Title_Should_Contain_Programming_Language(string expectedKeyword)
        {
            driver.Navigate().GoToUrl("https://www.epam.com/");

            //var acceptAllButton = driver.FindElement(By.XPath("//button[text()='Accept All']"));

            //if (acceptAllButton.Displayed)
            //{
            //    acceptAllButton.Click();
            //}

            driver.FindElement(By.LinkText("Careers")).Click();

            driver.FindElement(By.XPath("//a[.//span[text()='Start Your Search Here']]")).Click();

            var keywordInput = driver.FindElement(By.Name("search"));
            keywordInput.Clear();
            keywordInput.SendKeys(expectedKeyword);

            var remoteCheckbox = driver.FindElement(By.XPath("//div[@class='List_sideMenu__wGtLn']//input[@name='vacancy_type-Remote']"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", remoteCheckbox);

            driver.FindElement(By.ClassName("SearchBox_button__3ImF7"));

            wait.Until(d => d.FindElements(By.XPath("//div[@class='JobCard_panel__gTD7e']")).Any());

            var latestJobCard = driver.FindElement(By.XPath("//div[@class='JobCard_panel__gTD7e'][last()]//a"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", latestJobCard);

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", latestJobCard);

            var applyButton = driver.FindElement(By.Id("cta_job_apply_unauthorized"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", applyButton);

            applyButton.Click();

            var jobTitle = wait.Until(e => e.FindElement(By.TagName("h1")));

            jobTitle.Text.Should().Contain(expectedKeyword);
        }
    }
}
