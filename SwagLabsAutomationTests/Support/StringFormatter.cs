using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomationTests.Support
{
    public class StringFormatter
    {
        public string SeparateWordsByHyphen(string value)
        {
            return value.Replace(' ', '-');
        }
    }
}
