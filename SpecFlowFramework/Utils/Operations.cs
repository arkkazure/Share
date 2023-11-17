using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.Utils
{
    public  class Operations
    {
        public static String Getrandomname()
        {
            Random r = new Random();
            int randomNumber = r.Next(10000, 99999);
            string usernameRegisterPage = "Zee" + randomNumber;
            //string userfirstnameRegisterPage = "Ali" + randomNumber;
            return usernameRegisterPage;
            // return userfirstnameRegisterPage;
        }
        public static void Click(IWebDriver driver,By by)
        {
            driver.FindElement(by).Click();
            //wait code
        }
    }
}
