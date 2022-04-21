using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Elements
{
    public class Link : BaseElement
    {
        public Link(IWebDriver wevDriver, string name, By locator) : base(wevDriver, name, locator)
        {
        }
    }
}
