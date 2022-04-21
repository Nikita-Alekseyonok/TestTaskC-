using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Settings
{
    internal class TestData
    {
        public static string SitePath = "http://www.cars.com";

        public static Dictionary<string, string> firstCarSearchCriterias = new Dictionary<string, string>()
        {
            {"Make", "Audi"},
            {"Model", "A6"},
            {"Year", "2015"},
            {"Trim", "2.0T Premium"}
        };

        public static Dictionary<string, string> secondCarSearchCriterias = new Dictionary<string, string>()
        {
            {"Make", "BMW"},
            {"Model", "X6"},
            {"Year", "2015"},
            {"Trim", "sDrive35i"}
        };

        public static Dictionary<string, string> searchConditions = new Dictionary<string, string>()
        {
            {"Stock type", "Used cars"},
            {"Make", firstCarSearchCriterias["Make"]},
            {"Model", firstCarSearchCriterias["Model"]},
            {"Price", "No max price"},
            {"Distance", "20 miles"},
            {"Zip", "10001"}
        };
    }
}
