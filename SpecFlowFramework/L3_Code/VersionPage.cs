using OpenQA.Selenium;
using SpecFlowFramework.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.L3_Code
{
    public class VersionPage
    {
        By version3_2 = By.XPath("//a[@role='link'][normalize-space()='VERSION 3.2']");
        By version3_1 = By.XPath("//label[normalize-space()='VERSION 3.1']");

        ShareStateObjects sso;
        public VersionPage(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        public string GetLatestReleaseNotes()
        {
             String p1 = sso.driver.FindElement(By.XPath("//p[contains(text(),'- The account service REST API includes adding mas')]")).Text;
             String p2 = sso.driver.FindElement(By.XPath("//p[contains(text(),'- Swagger libraries are updated to the latest vers')]")).Text;
             Console.WriteLine(p1 + p2); // ???? assertion please..

             string str1 = p1 + p2;

            //String str1 = sso.driver.FindElement(By.Id("whats_new_section")).Text;

            return str1;

        }

        public void SelectPreviousVersion() {

            sso.driver.FindElement(version3_2).Click();
            sso.driver.FindElement(version3_1).Click();

        }

        public string GetPreviousReleaseNotes()
        {
            String p1 = sso.driver.FindElement(By.XPath("(//div[@class='gather_left'])[1]")).Text;
            String p2 = sso.driver.FindElement(By.XPath("(//div[@class='gather_left'])[2]")).Text;
            Console.WriteLine(p1 + p2); // ???? assertion please..

            string str1 = p1 + p2;
            return str1;

        }

    }
}
