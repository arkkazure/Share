using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowFramework.Utils
{
    public  class Data
    {


        public static Dictionary<string, string> LoadData(string fname)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            var report = File.ReadAllLines(fname);
            foreach (string line in report)
            {
                string[] keyvalue = line.Split('=');
                if (keyvalue.Length == 2)
                {
                    result.Add(keyvalue[0].Trim(), keyvalue[1].Trim());
                }
            }
            return result;

        }

    }
}
