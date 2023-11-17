using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFramework.Global;
using SpecFlowFramework.L3_Code;
using SpecFlowFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace SpecFlowFramework.L2_StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {

        ShareStateObjects sso;
        HomePage homePage;
        public HomePageSteps(ShareStateObjects sso)
        {
             this.sso = sso;
             homePage = new HomePage(sso);
        }

        [Then(@"(.*) is logged in successfully")]
        public void ThenUserIsLoggedInSuccessfully(string user)
        {
           
            bool usernameDisplayed = homePage.isUsernameDisplayed(user);
            Assert.IsTrue(usernameDisplayed);
        }
       

        [When(@"I search for the (.*)")]
        public void WhenISearchForTheItem(string item)
        {
            sso.item = item;
           // HomePage homePage = new HomePage(sso);
          DriverUtils.waitUntilCircleDisappears(sso.driver);
                homePage.SearchItem(item);
            
        }

        [Given(@"I add the special offer product to the cart and checkout")]
        public void AddSplProductToTheCartAndCheckout()
        {
           // HomePage homePage = new HomePage(sso);
            homePage.AddSplProduct();

        }

        [Then(@"I should see the user is created successfully")]
        public void ThenIShouldSeeTheUserIsCreatedSuccessfully()
        {
           // HomePage homePage = new HomePage(sso);
            bool userName = homePage.isSelectedUnameDisplayed();       
            Assert.IsTrue(userName);
        }

        [Given(@"I navigate to Popular Items Page and select below colors and qty for speakers")]
        public void GivenINavigateToPopularItemsPageAndSelectBelowProducts(Table table)
        {
           // HomePage homePage = new HomePage(sso);
            homePage.SelectPopularProducts(table);
        }

        [When(@"I click on Add to Cart")]
        public void WhenIClickOnAddToCart()
        {
            //HomePage homePage = new HomePage(sso);
            homePage.AddPopularItems();
        }

    }
}
