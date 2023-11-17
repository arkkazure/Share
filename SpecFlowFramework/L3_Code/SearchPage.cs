using OpenQA.Selenium;
using SpecFlowFramework.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.L3_Code
{
    public class SearchPage
    {

        By noPromotedProductDiv = By.ClassName("noPromotedProductDiv");
        ShareStateObjects sso;
        public SearchPage(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        public string getResultsText()
        {
            string str1 = sso.driver.FindElement(noPromotedProductDiv).Text;
            Console.WriteLine("No Promoted Div Deatils"+ str1);
            return str1;

        }
    }
}
