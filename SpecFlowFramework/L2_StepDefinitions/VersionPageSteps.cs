using NUnit.Framework;
using OpenQA.Selenium;
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
    public class VersionPageSteps
    {

        ShareStateObjects sso;
        public VersionPageSteps(ShareStateObjects sso)
        {
            this.sso = sso;
        }

        [Then(@"I see the below latest release notes in AOS page")]
        public void ThenISeeTheBelowLatestReleaseNotesInAOSPage(string multilineText)
        {

            Console.WriteLine("Input Text" + multilineText);
            VersionPage versionPage = new VersionPage(sso);
            string ResultText = versionPage.GetLatestReleaseNotes();
            Console.WriteLine("Result Text"+ ResultText);
            // Assert.AreEqual(multilineText, ResultText);
            Assert.IsTrue(ResultText.Contains(multilineText));
        }


        [When(@"I select the Previous AOS Version from the list")]
        public void WhenISelectThePreviousAOSVersionFromTheList()
        {
            VersionPage versionPage = new VersionPage(sso);
            versionPage.SelectPreviousVersion();
        }

        [Then(@"I see the below in AOS page")]
        public void ThenISeeTheBelowInAOSPage(string multilineText)
        {
            Console.WriteLine("Input Text" + multilineText);
            VersionPage versionPage = new VersionPage(sso);
            string ResultText = versionPage.GetPreviousReleaseNotes();
            Console.WriteLine("Result Text" + ResultText);
            // Assert.AreEqual(multilineText, ResultText);
            Assert.IsTrue(ResultText.Contains(multilineText));
        }
    }

}
