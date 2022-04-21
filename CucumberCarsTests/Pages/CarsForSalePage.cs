using CucumberCarsTests.Elements;
using CucumberCarsTests.Settings;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Pages
{
    public class CarsForSalePage : BasePage
    {
        private By searchResaltLocator = By.XPath("//div[@class='vehicle-card   ']");
        private string trimOptionLocator = "//div[@id='trim']//label[contains(text(), '{0}')]";
        private By yearSelectLocator = By.XPath("//div[@id='year']//select[@name='year_min']");
        private string yearOptionLocator = "//div[@id='year']//select[@name='year_min']//option[@value='{0}']";
        private By carPriceFromResultListLocator = By.XPath("//span[@class='primary-price']");



        public CarsForSalePage(string name, By unique_element_locator, IWebDriver webdriver) : base(name, unique_element_locator, webdriver)
        {
        }

        public void AddNewSearchConditions()
        {
            new Button(webdriver, "Car year select field", yearSelectLocator).ClickOnElement();
            new Button(webdriver, "Car year option", By.XPath(string.Format(yearOptionLocator, TestData.firstCarSearchCriterias["Year"]))).ClickOnElement();
            Assert.IsTrue(IsPageLoaded(), "Page didn't load");

            new Button(webdriver, "Car trim option", By.XPath(string.Format(trimOptionLocator, TestData.firstCarSearchCriterias["Trim"]))).ClickOnElement();
            Assert.IsTrue(IsPageLoaded(), "Page didn't load");
        }

        public string GetCarPriceFromResultList()
        {
            var carPriceFromResultListText = new Text(webdriver, "Car price from result list text", carPriceFromResultListLocator);

            return carPriceFromResultListText.GetText();
        }

        public bool IsResultListNotEmpty()
        {
            var resultVehicleCard = new VehicleCard(webdriver, "Result Vehicle Card", searchResaltLocator);
            var resultList = resultVehicleCard.FindElements();

            return resultList.Count() > 0;
        }

    }
}
