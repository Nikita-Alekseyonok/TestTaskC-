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
    public class ResearchPage : BasePage
    {
        public ToolBar toolBar;
        public SearchForm searchForm;
        public static By logoImageLocator = By.XPath("//img[contains(@class, 'header-logo')]");
        private By researchPageNavBarLocator = By.XPath("//nav//li[contains(text(), 'Research')]");


        private By makeCriterionLocator = By.XPath($"//select[@id='make-select']");
        private By modelCriterionLocator = By.XPath($"//select[@id='model-select']");
        private By yearCriterionLocator = By.XPath($"//select[@id='year-select']");

        private string makeCriterionMakeLocator = "//select[@id='make-select']//option[text()='{0}']";
        private string modelCriterionModelLocator = "//select[@id='model-select']//option[text()='{0}']";
        private string yearCriterionYearLocator = "//select[@id='year-select']//option[text()='{0}']";

        private By searchButtonLocatr = By.XPath("//button[contains(@class, 'search')]");

        private string headCarPageTitleLocator = "//div[@class='header-container']//h1[contains(text(), '{0} {1} {2}')]";

        private By trimCompareLinkLocator = By.XPath("//a[contains(@data-linkname, 'trim-compare')]");
        private string carTrimButtonLocator = "//button[contains(@id, 'trim')]//span[contains(text(), '{0}')]";

        private By countSeatsLocator = By.XPath("//tr/th[contains(text(), 'Seating')]/following::tr[1]/td");

        private By compareCarsLinkLocator = By.XPath("//div[@class='tools-section']//a[contains(@data-linkname, 'compare')]");
        private By carPriceLocator = By.XPath("//div[@class='msrp-container']//div");

        public ResearchPage(string name, By unique_element_locator, IWebDriver webdriver) : base(name, unique_element_locator, webdriver)
        {
            toolBar = new ToolBar("Tool Bar", logoImageLocator, webdriver);
            searchForm = new SearchForm("SearchForm", logoImageLocator, webdriver);
        }

        public string FindCarsAndSaveCarsTrimData(Dictionary<string, string> carData)
        {
            toolBar.GoToResearchAndReviewsPage();
            Assert.IsTrue(IsResearchPage(), $"{name} didn't load.");

            SetCarCriteriasAndSearch(carData);
            Assert.IsTrue(IsCarPageTitle(By.XPath(string.Format(headCarPageTitleLocator, carData["Year"], carData["Make"], carData["Model"]))),
                $"The page with the car {carData["Make"]} {carData["Model"]} { carData["Year"]} didnt open");
            GoToTrimCompareCar();
            var CarCountSeating = SaveCarTrimData(By.XPath(string.Format(carTrimButtonLocator, carData["Trim"])));

            return CarCountSeating;
        }

        public string GetCarPrice()
        {
            var carPriceText = new Text(webdriver, "Car price text", carPriceLocator);

            return carPriceText.GetText();
        }

        public void GoToCompareCars()
        {
            var compareCarsLink = new Link(webdriver, "Compare cars ink", compareCarsLinkLocator);
            compareCarsLink.ClickOnElement();
        }

        private void GoToTrimCompareCar()
        {
            var TrimCompareCarLink = new Link(webdriver, "Trim Compare car link", trimCompareLinkLocator);
            TrimCompareCarLink.ClickOnElement();
        }

        private string SaveCarTrimData(By carTrimButtonLocator)
        {
            var CarTrimButton = new Button(webdriver, "Car trim button", carTrimButtonLocator);
            CarTrimButton.ClickOnElement();

            var CountSeatingText = new Text(webdriver, "Count Seating Text", countSeatsLocator);

            return CountSeatingText.GetText();
        }

        private void SetCarCriteriasAndSearch(Dictionary<string, string> carData)
        {
            SetSearchCriterion(makeCriterionLocator, By.XPath(string.Format(makeCriterionMakeLocator, carData["Make"])));
            SetSearchCriterion(modelCriterionLocator, By.XPath(string.Format(modelCriterionModelLocator, carData["Model"])));
            SetSearchCriterion(yearCriterionLocator, By.XPath(string.Format(yearCriterionYearLocator, carData["Year"])));

            var SearchButton = new Button(webdriver, "Search Button", searchButtonLocatr);
            SearchButton.ClickOnElement();
        }

        private void SetSearchCriterion(By criterionLocator, By searchCriterionLocator) 
        {
            var CriterionButton = new Button(webdriver, "Criterion Button", criterionLocator);
            CriterionButton.ClickOnElement();

            var SearchCriterionButton = new Button(webdriver, "Search Criterion Button", searchCriterionLocator);
            SearchCriterionButton.ClickOnElement();
        }

        private bool IsCarPageTitle(By headCarPageTitleLoactaor) 
        {
            var CarPageTitle = new Text(webdriver, "Car page head title", headCarPageTitleLoactaor);
            return CarPageTitle.FindElement() != null;
        }

        public bool IsResearchPage()
        {
            var ResearcPagehNavBarText = new Text(webdriver, "Research page Navbar text", researchPageNavBarLocator);
            return ResearcPagehNavBarText.FindElement() != null;
        }

        public void IsCarPage(Dictionary<string, string> carData)
        {
            Assert.IsTrue(IsCarPageTitle(By.XPath(string.Format(headCarPageTitleLocator, carData["Year"], carData["Make"], carData["Model"]))),
                $"The page with the car {carData["Make"]} {carData["Model"]} { carData["Year"]} didnt open");
        }
    } 
}
