using SpecFlowFramework.Global;
using SpecFlowFramework.L3_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowFramework.L2_StepDefinitions
{
    [Binding]
    public class LoginPageSteps
    {
        ShareStateObjects sso;
      
        public LoginPageSteps(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        [Given(@"I navigate to Login page")]
        public void GivenINavigateToLoginPage()
        {
            LoginPage loginPage = new LoginPage(sso);
            loginPage.NaigatetoLoginPage();


        }

        [When(@"I submit (.*) and (.*)")]
        public void WhenISubmitZeeshanAndAliz(string uname, string pword)
        {
            LoginPage loginPage = new LoginPage(sso);
            loginPage.submitCredentials(uname, pword);
        }


    }
}
