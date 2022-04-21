using CucumberCarsTests.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Pages
{
    internal class AddCarForm:BasePage
    {
        private By submitCarToCampareButtonLocator = By.XPath("//div[@class='sds-field']//button[@class='sds-button']");
        private By makeSelectFieldLocator = By.XPath("//select[contains(@id, 'make')]");
        private By modelSelectFieldLocator = By.XPath("//select[contains(@id, 'model')]");
        private By yearSelectFieldLocator = By.XPath("//select[contains(@id, 'year')]");
        private By trimSelectFieldLocator = By.XPath("//select[contains(@id, 'trim')]");

        private string makeCriterionLocator = "//select[contains(@id, 'make')]//option[text()='{0}']";
        private string modelCriterionLocator = "//select[contains(@id, 'model')]//option[text()='{0}']";
        private string yearCriterionLocator = "//select[contains(@id, 'year')]//option[text()='{0}']";
        private string trimCriterionLocator = "//select[contains(@id, 'trim')]//option[contains(text(), '{0}')]";


        public AddCarForm(string name, By unique_element_locator, IWebDriver webdriver) : base(name, unique_element_locator, webdriver)
        {
        }

        public void SetCarCriteriasAndAddToComparison(Dictionary<string, string> carData)
        {
            SetSearchCriterion(makeSelectFieldLocator, By.XPath(string.Format(makeCriterionLocator, carData["Make"])));
            SetSearchCriterion(modelSelectFieldLocator, By.XPath(string.Format(modelCriterionLocator, carData["Model"])));
            SetSearchCriterion(yearSelectFieldLocator, By.XPath(string.Format(yearCriterionLocator, carData["Year"])));
            SetSearchCriterion(trimSelectFieldLocator, By.XPath(string.Format(trimCriterionLocator, carData["Trim"])));

            new Button(webdriver, " Submit Car to campare Button", submitCarToCampareButtonLocator).ClickOnElement();
        }

        public void SetSearchCriterion(By criterionLocator, By searchCriterionLocator)
        {
            var CriterionButton = new Button(webdriver, "Criterion Button", criterionLocator);
            CriterionButton.ClickOnElement();

            var SearchCriterionButton = new Button(webdriver, "Search Criterion Button", searchCriterionLocator);
            SearchCriterionButton.ClickOnElement();
        }
    }
}
