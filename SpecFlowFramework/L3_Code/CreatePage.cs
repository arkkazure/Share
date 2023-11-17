using OpenQA.Selenium;
using SpecFlowFramework.Global;
using SpecFlowFramework.L2_StepDefinitions.Hooks;
using SpecFlowFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.L3_Code
{
    public class CreatePage
    {

        By usernameRegisterPage = By.Name("usernameRegisterPage");
        By emailRegisterPage = By.Name("emailRegisterPage");
        By passwordRegisterPage = By.Name("passwordRegisterPage");
        By confirm_passwordRegisterPage = By.Name("confirm_passwordRegisterPage");
        By first_nameRegisterPage = By.Name("first_nameRegisterPage");
        By last_nameRegisterPage = By.Name("last_nameRegisterPage");
        By i_agree = By.Name("i_agree");
        By register_btn = By.Id("register_btn");
        By menuUserLink = By.Id("menuUserLink");

        ShareStateObjects sso;
        public CreatePage(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        public void CreateUser() {
            string rname = Operations.Getrandomname();
            //string fname = Getrandomname();
            
            sso.driver.FindElement(usernameRegisterPage).Click();
            sso.driver.FindElement(usernameRegisterPage).SendKeys(rname);
            sso.driver.FindElement(emailRegisterPage).Click();
            sso.driver.FindElement(emailRegisterPage).SendKeys(rname + "@gmail.com");
            sso.driver.FindElement(passwordRegisterPage).Click();
            sso.driver.FindElement(passwordRegisterPage).SendKeys("Pass1234*");
            sso.driver.FindElement(confirm_passwordRegisterPage).Click();
            sso.driver.FindElement(confirm_passwordRegisterPage).SendKeys("Pass1234*");
            sso.driver.FindElement(first_nameRegisterPage).Click();
            Console.WriteLine(LoaddataHooks.UserData["firstname"]);
            sso.driver.FindElement(first_nameRegisterPage).SendKeys(LoaddataHooks.UserData["firstname"]);
            sso.driver.FindElement(last_nameRegisterPage).Click();
            sso.driver.FindElement(last_nameRegisterPage).SendKeys(LoaddataHooks.UserData["lastname"]);

        }
 


            public void AgreeTerms() {
            sso.driver.FindElement(i_agree).Click();
            sso.driver.FindElement(register_btn).Click();
           // Thread.Sleep(2000);
            Console.WriteLine(sso.driver.FindElement(menuUserLink).Text);

        }
    }
}
