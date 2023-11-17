using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowFramework.Global;
using SpecFlowFramework.L2_StepDefinitions.Hooks;
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
    internal class OrderPaymentPageSteps
    {
        ShareStateObjects sso;
        public OrderPaymentPageSteps(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        [Given(@"I login as ExistingUser")]
        public void GivenILoginAsExistingUser()
        {
            OrderPaymentPage orderPaymentPage = new OrderPaymentPage(sso);
            //orderPaymentPage.ExistingUserLogin();
            LoginPage loginPage = new LoginPage(sso);
            loginPage.submitCredentials(LoaddataHooks.LoginCrendtials["username"], LoaddataHooks.LoginCrendtials["password"]);
         
        }

        [When(@"I choose the payment menthod as Mastercard")]
        public void WhenIChooseThePaymentMenthodAsMastercard()
        {
            OrderPaymentPage orderPaymentPage = new OrderPaymentPage(sso);
            orderPaymentPage.SelectPaymentMethod();
        }

        [When(@"I choose the payment menthod as Safepay")]
        public void WhenIChooseThePaymentMenthodAsSafePay()
        {
            OrderPaymentPage orderPaymentPage = new OrderPaymentPage(sso);
            orderPaymentPage.SelectSafePay();
        }
        [When(@"I Place an order")]
        public void WhenIPlaceAnOrder()
        {
            OrderPaymentPage orderPaymentPage = new OrderPaymentPage(sso);
            orderPaymentPage.PlaceanOrder();
        }

    
        [Then(@"I see the order is successfully placed")]
        public void ThenISeeTheOrderIsSuccessfullyPlaced()
        {
            OrderPaymentPage orderPaymentPage = new OrderPaymentPage(sso);
            bool orderPaymentDisplayed = orderPaymentPage.isOrderPaymentDisplayed();            
            Assert.IsTrue(orderPaymentDisplayed);
        }

        [Then(@"I can see <(.*)> products added to my shopping basket")]
        public void ThenICanSeeTheProductsInMyShoppingBasket(string total)
        {

            OrderPaymentPage orderPaymentPage = new OrderPaymentPage(sso);
            string totalPrice = orderPaymentPage.ProductsInMyShoppingBasket(total);
            Console.WriteLine("total price"+ totalPrice);
            Assert.AreEqual(total, totalPrice);
        }

    }
}
