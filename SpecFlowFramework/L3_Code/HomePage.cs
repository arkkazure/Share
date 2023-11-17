using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowFramework.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowFramework.L3_Code
{
    public class HomePage
    {
               
        By seeOfeerBtn = By.Id("see_offer_btn");        
        By menuUserLink = By.Id("menuUserLink");
        By searchSection = By.Id("searchSection");
        By autoComplete = By.Id("autoComplete");
        By closeSearchForce = By.XPath("//div[@data-ng-click='closeSearchForce()']");
        By save_to_cart = By.Name("save_to_cart");
        By checkOutPopUp = By.Id("checkOutPopUp");
        By popular_items = By.XPath("(//article[@id='popular_items']//label)[3]");
        By blackColor = By.XPath("//span[@title='BLACK' and @id='bunny']");
        By blueColor = By.XPath("//span[@title='BLUE' and @id='bunny']");
        By quantity = By.Name("quantity");
        

        ShareStateObjects sso;
        public HomePage(ShareStateObjects sso)
        {
            this.sso = sso; 
        }
            
        public bool isUsernameDisplayed(string uname)
        {
            bool usernameDisplayed = sso.driver.FindElement(By.XPath("(//span[text()='"+uname+"'])[2]")).Displayed;
            return usernameDisplayed;   
        }

        public bool isSelectedUnameDisplayed()
        {
            bool usernameDisplayed = sso.driver.FindElement(menuUserLink).Displayed;
            return usernameDisplayed;
        }
        public void SearchItem (string itemName)
        {
           
            sso.driver.FindElement(searchSection).Click();

            var searchbox = sso.driver.FindElement(autoComplete);
            Actions action = new Actions(sso.driver);
            action.MoveToElement(searchbox).SendKeys(itemName).SendKeys(Keys.Enter).Build().Perform();

            sso.driver.FindElement(closeSearchForce).Click();
        }

        public void AddSplProduct() {

            sso.driver.FindElement(seeOfeerBtn).Click();
            sso.driver.FindElement(save_to_cart).Click();
            sso.driver.FindElement(checkOutPopUp).Click();

        }

        public void SelectPopularProducts(Table table) {

            int quantity = 0;

            sso.driver.FindElement(popular_items).Click();

            for (int i = 0; i < table.RowCount; i++)
            {
                sso.driver.FindElement(By.XPath("(//span[@id='bunny' and @title='" + table.Rows[i][0].ToUpper() + "'])")).Click();
                sso.driver.FindElement(By.Name("quantity")).Click();
                sso.driver.FindElement(By.Name("quantity")).SendKeys(table.Rows[i][1]);
                sso.driver.FindElement(By.Name("save_to_cart")).Click();
                quantity += int.Parse(table.Rows[i][1]);
            }

            sso.popular_quantity = quantity;

            /** Commented this Code 15-03 By Mansoor to work with Tables

            // *******Validating the popular items added to the shopping cart*******
            sso.driver.FindElement(popular_items).Click(); //select the 3rd item as per requirement
            sso.driver.FindElement(blackColor).Click(); //ClassName("bunny productColor ng-scope BLACK")
            sso.driver.FindElement(quantity).Click();
            sso.driver.FindElement(quantity).SendKeys("2");
            sso.driver.FindElement(save_to_cart).Click();
            sso.driver.FindElement(blueColor).Click();  //ClassName("bunny productColor ng-scope Blue")
            sso.driver.FindElement(quantity).Click();
            sso.driver.FindElement(quantity).SendKeys("1");
            sso.driver.FindElement(save_to_cart).Click();
            sso.driver.FindElement(blueColor).Click();  //ClassName("bunny productColor ng-scope Blue")
            sso.driver.FindElement(quantity).Click();
            sso.driver.FindElement(quantity).SendKeys("1");
           
            **** Comment End Here */

        }

        public void AddPopularItems() {

            sso.driver.FindElement(checkOutPopUp).Click();
           
        }
    }
}
