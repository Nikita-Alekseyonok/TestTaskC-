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
    public class CompareCarsPage:BasePage
    {
        private AddCarForm addCarForm;
        private ToolBar toolBar;
        public static By logoImageLocator = By.XPath("//img[contains(@class, 'header-logo')]");
        private By compareCarsPageNavBarLocator = By.XPath("//nav//li[contains(text(), 'Compare cars')]");

        private By addFirstCarToComapreButtonLocator = By.XPath("//div[contains(@class, 'card1')]//a[@class='add-car']");
        private By addSecondCarToComapreButtonLocator = By.XPath("//div[contains(@class, 'card2')]//a[@class='add-car']");

        private By seeCamparisonCarsButtonLocator = By.XPath("//div[@class='comparison-container']//button[@class='sds-button']");

        private By firstCarSeatsCountLocator = By.XPath("//tr/td[contains(text(), 'Seats')]/following::tr[1]/td[1]");
        private By secondCarSeatsCountLocator = By.XPath("//tr/td[contains(text(), 'Seats')]/following::tr[1]/td[2]");

        private string carPageLinkLocator = "//a[@data-slugs='{0}-{1}-{2}' and contains(@data-linkname, 'research')]";

        public CompareCarsPage(string name, By unique_element_locator, IWebDriver webdriver) : base(name, unique_element_locator, webdriver)
        {
            addCarForm = new AddCarForm("Add car form", logoImageLocator, webdriver);
            toolBar = new ToolBar("Tool Bar", logoImageLocator, webdriver);
        }

        public void CompareCarsSeatsCount(string expectedFirstCarSeatsCount, string expectedSecondCarSeatsCount)
        {
            var firstCarSeatsCount = GetSeatsCount(firstCarSeatsCountLocator);
            Assert.AreEqual(expectedFirstCarSeatsCount, firstCarSeatsCount, $"Expected result and received result don't match");

            var secondCarSeatsCount = GetSeatsCount(secondCarSeatsCountLocator);
            Assert.AreEqual(expectedSecondCarSeatsCount, secondCarSeatsCount, $"Expected result and received result don't match");
        }

        private string GetSeatsCount(By carSeatsCountLocator)
        {
            var CarSeatsCountText = new Text(webdriver, "Car Seats Count Text", carSeatsCountLocator);
            return CarSeatsCountText.GetText();
        }

        public void GoToCarPage(Dictionary<string, string> carData)
        {
            new Link(webdriver, "Car page link", By.XPath(string.Format(carPageLinkLocator, carData["Make"].ToLower(),
                                                                                            carData["Model"].ToLower(),
                                                                                            carData["Year"].ToLower()))).ClickOnElement();
        }

        public bool IsCompareCarsPage()
        {
            var ResearcPagehNavBarText = new Text(webdriver, "Research page Navbar text", compareCarsPageNavBarLocator);
            return ResearcPagehNavBarText.FindElement() != null;
        }

        public void SlectCarsAndGoToComparisonSelectedCars() 
        {
            new Button(webdriver, "Add Car To Comapr Button", addFirstCarToComapreButtonLocator).ClickOnElement();
            addCarForm.SetCarCriteriasAndAddToComparison(TestData.firstCarSearchCriterias);

            new Button(webdriver, "Add Car To Comapr Button", addSecondCarToComapreButtonLocator).ClickOnElement();
            addCarForm.SetCarCriteriasAndAddToComparison(TestData.secondCarSearchCriterias);

            var SeeCamparisonCarsButton = new Button(webdriver, "See camparison cars button", seeCamparisonCarsButtonLocator);
            SeeCamparisonCarsButton.ClickOnElement();
        }
    }
}
