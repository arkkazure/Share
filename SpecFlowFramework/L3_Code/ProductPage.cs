using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowFramework.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.L3_Code
{
    
    
    public class ProductPage
    {
               
        By SelectQuantity           = By.Name("quantity");
        By SaveToChart              = By.Name("save_to_cart");      
    //  By SelectShoppingCartLink   = By.XPath("//a[@id='shoppingCartLink']//*[name()='svg']");
        By SelectShoppingCartLink   = By.Id("shoppingCartLink");
        By CheckOutButton           = By.Id("checkOutButton");
        By RItemName = By.XPath("//h3[@class='ng-binding']");
        By RQnty = By.XPath("//label[@class='ng-binding']");
        By RColor = By.XPath("//span[@class='ng-binding']");
        By RTotal = By.XPath("//span[@class='roboto-medium totalValue ng-binding']");

        ShareStateObjects sso;
        public ProductPage(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        public void  SelectProductItemandColour (string item, string qauntity, string color)
        {

            sso.driver.FindElement(By.XPath($"//a[normalize-space()='{item}']")).Click();

            sso.driver.FindElement(By.XPath($"//span[@title='{color}' and @id='rabbit']")).Click();
            sso.driver.FindElement(SelectQuantity).Click();
            sso.driver.FindElement(SelectQuantity).SendKeys(qauntity);
            sso.driver.FindElement(SaveToChart).Click();
            
            /***   Zesshan Bhai Code to be removed
                        sso.driver.FindElement(SelectHPEliteG2PadLaptop).Click(); //select the HP ElitePad 1000 G2 Tablet item as per requirement
                        sso.driver.FindElement(SelectBlueColor).Click();
                        sso.driver.FindElement(SelectQuantity).Click();
                        sso.driver.FindElement(SelectQuantity).SendKeys("2");
                        sso.driver.FindElement(SaveToChart).Click();
                        sso.driver.FindElement(GoToTabletScreen).Click();
                        sso.driver.FindElement(SelectHPEliteG1PadLaptop).Click(); //select the HP Elite x2 1011 G1 Tablet item as per requirement
                        sso.driver.FindElement(SelectGrayColor).Click();
                        sso.driver.FindElement(SelectQuantity).Click();
                        sso.driver.FindElement(SelectQuantity).SendKeys("1");
                        sso.driver.FindElement(SaveToChart).Click();
                        Thread.Sleep(4000);

            ***************************************/

        }


        public void CheckOutItem()
        {

            sso.driver.FindElement(SelectShoppingCartLink).Click();
            //driver.FindElement(By.Name("menuCart")).Click();
            sso.driver.FindElement(CheckOutButton).Click();

        }

        public Dictionary<string, string> Getvalues()
        {

            string ItemName = sso.driver.FindElement(RItemName).Text;
            Console.WriteLine(ItemName);
            string Quantity = sso.driver.FindElement(RQnty).Text;
            Console.WriteLine(Quantity);
            string Color = sso.driver.FindElement(RColor).Text;
            Console.WriteLine(Color);
            string Total = sso.driver.FindElement(RTotal).Text;
            Console.WriteLine(Total);

            Dictionary<string, string> result = new Dictionary<string, string>();
            
            result.Add("Item", ItemName);
            result.Add("Quantity", Quantity);
            result.Add("Color", Color);
            result.Add("Total", Total);

            return result;

            // Dynamic Variable creation 

            //var data = new { Total };
            //return data;
        }
    }

}

