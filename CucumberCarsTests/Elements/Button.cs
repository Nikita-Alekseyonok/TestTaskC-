using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Elements
{
    internal class Button : BaseElement
    {
        public Button(IWebDriver wevDriver, string name, By locator) : base(wevDriver, name, locator)
        {
        }
    }
}
