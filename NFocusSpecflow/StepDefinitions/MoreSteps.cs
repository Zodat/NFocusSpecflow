using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFocusSpecflow.StepDefinitions

    
{
    [Binding]
    public class MoreSteps
    {
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver _driver;
    public MoreSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._driver = (IWebDriver)_scenarioContext["mydriver"];
        }
        [When(@"I search for '(.*)'")]
        public void WhenISearchForEdgewords(string searchTerm)
        {
            Console.WriteLine((string)_scenarioContext["pagetitle"]);
            _driver.FindElement(By.CssSelector("input[name=q]")).SendKeys(searchTerm + Keys.Enter);
        }
    }
}
