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
    public class EnvHooks
    {
        public static Dictionary<string, string> EnvDetails;

   [BeforeTestRun]
        public static void loadEnvData()
        {
            string envSelected = TestContext.Parameters.Get("env") ?? "Dev";


            Console.WriteLine("this is coming from outside cmd "+envSelected);
            string filename = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/../../../Environment/" + envSelected + ".txt";

            EnvDetails = Data.LoadData(filename);
        }



       
    }
}
