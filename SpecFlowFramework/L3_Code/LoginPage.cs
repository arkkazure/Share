using OpenQA.Selenium;
using SpecFlowFramework.Global;
using SpecFlowFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.L3_Code
{
    public class LoginPage
    {
        By usermenu = By.Id("hrefUserIcon");
        By unameField = By.Name("username");
        By pwordField = By.XPath("//input[@name='password']");
        By signinBtn = By.Id("sign_in_btn");

        private IWebDriver driverx;

        ShareStateObjects sso;
        public LoginPage (ShareStateObjects sso)
        {
            this.sso = sso;
            driverx = sso.driver;
        }



        public void NaigatetoLoginPage()
        {
           // DriverUtils.waitUntilCircleDisappears(sso.driver);
            driverx.FindElement(usermenu).Click();
            DriverUtils.waitUntilCircleDisappears(sso.driver);
        }

        //This is  with out wrapper calling whrere needed
        public void submitCredentials(string uname, string pword)
        {
          
            driverx.FindElement(unameField).Click();
           // DriverUtils.waitUntilCircleDisappears(sso.driver);
            driverx.FindElement(unameField).SendKeys(uname);
            sso.driver.FindElement(pwordField).Click();
           // DriverUtils.waitUntilCircleDisappears(sso.driver);
            sso.driver.FindElement(pwordField).SendKeys(pword);
            
            sso.driver.FindElement(signinBtn).Click();
            DriverUtils.waitUntilCircleDisappears(sso.driver);
        }


        //This is calling the wrapper
        public void submitCredentials1(string uname, string pword)
        {

            Operations.Click(sso.driver, unameField);
            sso.driver.FindElement(unameField).SendKeys(uname);

            Operations.Click(sso.driver, pwordField);
            sso.driver.FindElement(pwordField).SendKeys(pword);
            
     
            Operations.Click(sso.driver, signinBtn);
           
            
        }
    }
}
