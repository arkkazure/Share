using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using SpecFlowFramework.Global;
using SpecFlowFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

//move as required
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(5)]
namespace SpecFlowFramework.L2_StepDefinitions.Hooks
{
    [Binding]
    public class BrowserHooks
    {

        
        ShareStateObjects sso;
        public BrowserHooks(ShareStateObjects sso)
        {
            this.sso = sso;
        }


        [BeforeScenario]
        public void SetupBrowser()
        {
            //   string browserSelected = TestContext.Parameters["browser"];

            
            string browserSelected = TestContext.Parameters.Get("browser") ?? "chrome";

            if (browserSelected.ToLower() == "edge")
            {
                sso.driver = new EdgeDriver();

            }else
            {
                sso.driver = new ChromeDriver();
            }

           
            sso.driver.Url = EnvHooks.EnvDetails["base.url"];
            sso.driver.Manage().Window.Maximize();
            sso.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
        }

        [AfterScenario]
        public void TearBrowser()
        {
            sso.driver.Quit();

        }
    }
}
