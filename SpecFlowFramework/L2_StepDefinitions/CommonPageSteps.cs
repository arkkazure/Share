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
    public class CommonPageSteps
    {

        ShareStateObjects sso;
        public CommonPageSteps(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        [Given(@"I navigate to homepage")]
        public void GivenINavigateToHomepage()
        {
            CommonPage commonPage = new CommonPage(sso);
            commonPage.navigateToHomePage();
          
        }

        [Given(@"I navigate to Special Offers Page")]
        public void GivenINavigateToSpecialOffersPage()
        {
            CommonPage commonPage = new CommonPage(sso);
            commonPage.NaigatetoSpecialOfferPage();

        }

        [Given(@"I navigate to Version page")]
        public void GivenINavigateToVersionPage()
        {
            CommonPage commonPage = new CommonPage(sso);
            commonPage.NavigateToVersionPage();
        }

        [Given(@"I  navigated to create user page")]
        public void GivenINavigatedToCreateUserPage()
        {
            CommonPage commonPage = new CommonPage(sso);
            commonPage.NavigatedToCreateUserPage();
        }

        [Given(@"I navigate to TabletSections")]
        public void GivenINavigateToTabletSections()
        {
            CommonPage commonPage = new CommonPage(sso);
            commonPage.NavigateToTabletSectionsPage();
        }

    }
}
