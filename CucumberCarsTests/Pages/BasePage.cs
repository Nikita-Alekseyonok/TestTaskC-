using CucumberCarsTests.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Pages
{
    public class BasePage
    {
        public string name;
        public By unique_element_locator;
        public IWebDriver webdriver;

        public BasePage(string name, By unique_element_locator, IWebDriver webdriver)
        {
            this.name = name;
            this.unique_element_locator = unique_element_locator;
            this.webdriver = webdriver;
        }

        public bool IsPageLoaded() 
        {
            var unique_element = new BaseElement(webdriver, "Cars.com logo", unique_element_locator);
            return unique_element != null;
        }
    }
}
