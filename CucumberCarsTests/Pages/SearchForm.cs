using CucumberCarsTests.Elements;
using CucumberCarsTests.Settings;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Pages
{
    public class SearchForm : BasePage
    {

       
        private By makesSelectLocator = By.XPath("//select[@id='makes']");
        private By modelsSelectLocator = By.XPath("//select[@id='models']");
        private By zipFieldLocator = By.XPath("//input[@id='make-model-zip']");
        private By stockTypeSelectLocator = By.XPath("//select[@id='make-model-search-stocktype']");
        private By maxPriceSelectLocator = By.XPath("//select[@id='make-model-max-price']");
        private By maxDistanceFieldLocator = By.XPath("//select[@id='make-model-maximum-distance']");
        private string сriterionLocator = "//option[text()='{0}']";

        private By searchButton = By.XPath("//button[@data-searchtype='make']");

        public SearchForm(string name, By unique_element_locator, IWebDriver webdriver) : base(name, unique_element_locator, webdriver)
        {
        }

        public void FillSearchFormAndSearch()
        {
            SetCriterion(makesSelectLocator, TestData.searchConditions["Make"]);
            SetCriterion(modelsSelectLocator, TestData.searchConditions["Model"]);
            SetCriterion(stockTypeSelectLocator, TestData.searchConditions["Stock type"]);
            SetCriterion(maxPriceSelectLocator, TestData.searchConditions["Price"]);
            SetCriterion(maxDistanceFieldLocator, TestData.searchConditions["Distance"]);

            new TextField(webdriver, "Zip Text Field", zipFieldLocator).SetText(TestData.searchConditions["Zip"]);
            new Button(webdriver, "Search Button", searchButton).ClickOnElement();
        }

        private void SetCriterion(By selectFieldLocator, string criterion)
        {
            new Button(webdriver, "Select Field", selectFieldLocator).ClickOnElement();
            new Button(webdriver, "Criterion", By.XPath(string.Format(сriterionLocator, criterion))).ClickOnElement();
        }
    }
}
