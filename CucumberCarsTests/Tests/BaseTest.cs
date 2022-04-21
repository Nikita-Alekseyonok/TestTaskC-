using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace CucumberCarsTests
{
    public class BaseTest
    {
        protected IWebDriver _webDriver;


        [OneTimeSetUp]
        protected void OneTimeSetUp() 
        {
            _webDriver = new ChromeDriver();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown() 
        {
            _webDriver.Quit();
        }

        [SetUp]
        protected void SetUp()
        { 
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Manage().Window.Maximize();
        }
    }
}
