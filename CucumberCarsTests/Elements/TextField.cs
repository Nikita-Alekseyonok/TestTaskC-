using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Elements
{
    public class TextField : BaseElement
    {
        public TextField(IWebDriver wevDriver, string name, By locator) : base(wevDriver, name, locator)
        {
        }

        public void SetText(string text)
        {
            //logger.LogInformation($"{name}: set text");
            FindElement().SendKeys(text);
        }
    }
}
