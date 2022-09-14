using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using static NFocusSpecflow.StepDefinitions.Hooks;

namespace NFocusSpecflow.StepDefinitions
{
    [Binding]
    public class GoogleStepDefinitions
    {

        string title;

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public GoogleStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._driver = (IWebDriver)_scenarioContext["mydriver"];
        }

        [Given(@"Google is open")] //Alternative phrasing
        [Given(@"I am on the (?i)Google(?-i) Homepage")] //Google is case insesitive
        public void GivenIAmOnTheGoogleHomepage()
        {
            
            _driver.Url = "https://www.google.co.uk/";
            IWebElement acceptButton = _driver.FindElement(By.Id("L2AGLb"));
            acceptButton.Click();
            _scenarioContext["pagetitle"] = _driver.Title;
        }

      



        [Then(@"'(.*)' is the top result")]
        public void ThenEdgewordsIsTheTopResult(string searchTerms)
        {
            Thread.Sleep(1000);
            string topsearch = _driver.FindElement(By.CssSelector("div#rso > div:first-of-type")).Text;
            Assert.That(topsearch, Does.Contain(searchTerms), "Not in the top result");
            //Fluent assertion
            //topsearch.Should().Contain("Edgewords");
            


        }
        [Then(@"I see in the results")]
        public void ThenISeeInTheResults(Table table)
        {
            string searchResults = _driver.FindElement(By.Id("rso")).Text;
            //Need to unpack the data table
            foreach(var row in table.Rows)
            {
                Assert.That(searchResults, Does.Contain(row["url"]), "Didn't find url");
                Assert.That(searchResults, Does.Contain(row["title"]), "Title is missing");
            }
        }
        //A comment
    }
}