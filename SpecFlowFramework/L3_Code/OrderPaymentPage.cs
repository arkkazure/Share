using OpenQA.Selenium;
using SpecFlowFramework.Global;
using SpecFlowFramework.L2_StepDefinitions.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.L3_Code
{
    public class OrderPaymentPage
    {
        By usernameInOrderPayment = By.Name("usernameInOrderPayment");
        By passwordInOrderPayment = By.Name("passwordInOrderPayment");
        By login_btnundefined = By.Id("login_btnundefined");
        By next_btn = By.Id("next_btn");
        By masterCredit = By.Name("masterCredit");
        By pay_now_btn_MasterCredit = By.Id("pay_now_btn_MasterCredit");
        By pay_now_btn_SAFEPAY = By.Id("pay_now_btn_SAFEPAY");
        
        By pselect_SAFEPAY = By.Name("safepay");
        By orderPaymentSuccess = By.Id("orderPaymentSuccess");
        By totalPriceValue = By.XPath("(//span[@class='roboto-medium cart-total ng-binding'])[1]");
        By totalQuantity = By.XPath("//a[@id='shoppingCartLink']//span[@class='cart ng-binding'][normalize-space()='9']");
        By safepayUsername = By.Name("safepay_username");
        By safepayPwd = By.Name("safepay_password"); 
        ShareStateObjects sso;
        public OrderPaymentPage(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        public void ExistingUserLogin()
        {

            sso.driver.FindElement(usernameInOrderPayment).Click();
            Console.WriteLine(LoaddataHooks.LoginCrendtials["username"]);
            sso.driver.FindElement(usernameInOrderPayment).SendKeys(LoaddataHooks.LoginCrendtials["username"]);

            sso.driver.FindElement(passwordInOrderPayment).Click();
            Console.WriteLine(LoaddataHooks.LoginCrendtials["password"]);

            sso.driver.FindElement(passwordInOrderPayment).SendKeys(LoaddataHooks.LoginCrendtials["password"]);

            sso.driver.FindElement(login_btnundefined).Click();
            sso.driver.FindElement(next_btn).Click();

        }

        public void SelectPaymentMethod()
        {

            sso.driver.FindElement(masterCredit).Click();
            Thread.Sleep(2000);
            sso.driver.FindElement(pay_now_btn_MasterCredit).Click();
      

        }

        public void SelectSafePay()
        {
            sso.driver.FindElement(pselect_SAFEPAY).Click();
         /*   sso.driver.FindElement(safepayUsername).Click();
            sso.driver.FindElement(safepayUsername).SendKeys("Mansoor");
            sso.driver.FindElement(safepayPwd).Click();
            sso.driver.FindElement(safepayPwd).SendKeys("Mansoor1");    */        
            sso.driver.FindElement(pay_now_btn_SAFEPAY).Click();
            Thread.Sleep(2000);



        }

        public void PlaceanOrder()
        {

            sso.driver.FindElement(pay_now_btn_MasterCredit).Click();
            Thread.Sleep(2000);
        }

        public bool isOrderPaymentDisplayed()
        {

            bool orderPaymentDisplayed = sso.driver.FindElement(orderPaymentSuccess).Displayed;
            return orderPaymentDisplayed;

        }

        public string ProductsInMyShoppingBasket(string totalItems)
        {
            totalItems = sso.driver.FindElement(By.Id("shoppingCartLink")).Text;
            Console.WriteLine("Total Quantity   " + totalItems);
            return totalItems;
        }
    }
}
