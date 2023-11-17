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
        public class SearchPageSteps
    {

        ShareStateObjects sso;
        public SearchPageSteps(ShareStateObjects sso)
        {
            this.sso = sso;
        }



        [Then(@"I should get the search (.*)")]
        public void ThenIShouldGetTheSearchResultsDisplayed(string result)
        {
            SearchPage searchPage = new SearchPage(sso);
            string ResultText = searchPage.getResultsText();

            Console.WriteLine("Result Text : "+ ResultText);
            int startIndex = ResultText.IndexOf("CATEGORIES") + 12;
            int endIndex = (sso.item).Length;
       

            Console.WriteLine("Check the input Keyword"+sso.item);
            Console.WriteLine(startIndex);
            Console.WriteLine(endIndex);
            if(result.Equals("Results displayed"))
            {
                Assert.IsTrue(ResultText.ToUpper().Contains(sso.item.ToUpper()));
                Assert.IsFalse(ResultText.Contains("No results for"));
               // Assert.AreEqual(sso.item.ToUpper(), ResultText.Substring(startIndex, endIndex).ToUpper()); ;
            }
            if (result.Equals("No Results displayed"))
            {
                Assert.IsTrue(ResultText.Contains("No results for"));
            }



        }
    }
}
