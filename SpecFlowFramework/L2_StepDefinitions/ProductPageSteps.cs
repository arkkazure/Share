using NUnit.Framework;
using SpecFlowFramework.Global;
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
    public class ProductPageSteps
    {

        ShareStateObjects sso;

        public ProductPageSteps(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        [Given(@"I select the (.*),(.*),(.*) and add to cart")]
        public void SelectTablets(string item, string qauntity,string color)
        {

            ProductPage productPage = new ProductPage(sso);
            productPage.SelectProductItemandColour(item, qauntity, color); 

        }

        [When(@"I checkout the prodcuts")]
        public void WhenICheckoutTheProdcuts()
        {
            ProductPage productPage = new ProductPage(sso);
            productPage.CheckOutItem();


        }

        [Then(@"I validate the (.*),(.*),(.*) and (.*) are added to the order summary")]
        public void ThenValidateTheOrderSummary(string item, string qauntity, string color,string price)
        {
            ProductPage productPage = new ProductPage(sso);
            Dictionary<string, string> resultData = productPage.Getvalues();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(item.ToUpper(), resultData["Item"]);
                Assert.AreEqual("QTY: "+qauntity, resultData["Quantity"]);
                Assert.AreEqual(color, resultData["Color"]);
                Assert.AreEqual(price, resultData["Total"]);
            });

            }
    }
}
