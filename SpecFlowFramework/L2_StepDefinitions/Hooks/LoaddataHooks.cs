using NUnit.Framework;
using SpecFlowFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowFramework.L2_StepDefinitions.Hooks
{
 [Binding]
    public class LoaddataHooks
    {
        public static Dictionary<string, string> UserData;
        public static Dictionary<string, string> LoginCrendtials;

        [BeforeTestRun]
        public static void LoadUserData()
        {
            // make it relative path
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/../../../Data/UserData.txt";


            UserData = Data.LoadData(filename);
        }






        [BeforeScenario("existinguser")]
        public void LoadLoginCreds(string username, string password)
        {
            // make it relative path
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/../../../Data/LoginCredentials.txt";

            LoginCrendtials = Data.LoadData(filename);

        }

    }
}

