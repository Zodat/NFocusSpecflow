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
    public class Hooks
    {

        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;



        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
       
       

        [Before]
        public void SetUp()
        {
            
            driver = new ChromeDriver();
            _scenarioContext["mydriver"] = driver;
        }



        [After]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
