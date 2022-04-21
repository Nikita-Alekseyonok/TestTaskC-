using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace CucumberCarsTests.Elements
{
    public class BaseElement
    {
        protected IWebDriver webDriver;
        protected string name;
        protected By locator;

        public BaseElement(IWebDriver wevDriver, string name, By locator)
        {
            this.webDriver = wevDriver;
            this.name = name;
            this.locator = locator;
        }

        public IWebElement FindElement(int seconds = 10)
        {
            //logger.LogInformation($"{name}: find element");
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementExists(locator));
            return webDriver.FindElement(locator);
        }

        public void ClickOnElement(int seconds = 10)
        {
            //logger.LogInformation($"{name}: click on element");
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
            FindElement().Click();
        }

        public ReadOnlyCollection<IWebElement> FindElements(int seconds  = 10)
        {
            //logger.LogInformation($"{name}: find elements");
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementExists(locator));
            return webDriver.FindElements(locator);
        }
    }
}
