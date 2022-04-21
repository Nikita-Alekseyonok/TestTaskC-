using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Utils
{
    public class StringUtils
    {
        public static bool IsFirstStringGreaterThenSecondString(string str1, string str2)
        {
            var result = string.Compare(str1, str2);

            return result == 1 ? true : false;
        }
    }
}
