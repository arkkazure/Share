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
    public class CreatePageSteps
    {
        ShareStateObjects sso;
        public CreatePageSteps(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        [When(@"I submit the user details to create user")]
        public void WhenISubmitTheUserDetailsToCreateUser()
        {
            CreatePage createPage = new CreatePage(sso);

            createPage.CreateUser();
        }

        [When(@"I agree the terms")]
        public void WhenIAgreeTheTerms()
        {
            CreatePage createPage = new CreatePage(sso);
            createPage.AgreeTerms();
        }
    }
}
