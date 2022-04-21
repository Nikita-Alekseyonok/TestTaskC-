using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Elements
{
    public class Text : BaseElement
    {
        public Text(IWebDriver wevDriver, string name, By locator) : base(wevDriver, name, locator)
        {
        }

        public string GetText()
        {
            //logger.LogInformation($"{name}: get text");
            return FindElement().Text;
        }
    }
}
