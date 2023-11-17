using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowFramework.Global;
using SpecFlowFramework.L2_StepDefinitions.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.L3_Code
{
    public class CommonPage
    {
        By special_Offer = By.LinkText("SPECIAL OFFER");
        By menuHelp = By.Id("menuHelp");
        By aos_Versions = By.XPath("//div[@id='helpMiniTitle']/label[text()='AOS Versions']");

        ShareStateObjects sso;
        public CommonPage(ShareStateObjects sso)
        {
            this.sso = sso;
        }
        public void navigateToHomePage()
        {
            sso.driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/");
        }

        public void NaigatetoSpecialOfferPage()
        {
            var splOffer = sso.driver.FindElement(special_Offer);
            Actions action = new Actions(sso.driver);
            action.MoveToElement(splOffer).Click();

        }

        public void NavigateToVersionPage()
        {
            sso.driver.FindElement(menuHelp).Click();
            sso.driver.FindElement(aos_Versions).Click();

        }

        public void NavigatedToCreateUserPage()
        {

            sso.driver.Navigate().GoToUrl(EnvHooks.EnvDetails["base.url"] + "#/register");


        }

        public void NavigateToTabletSectionsPage()
        {

            sso.driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/#/search/3?viewAll=tab");
        }

            

    }
}
