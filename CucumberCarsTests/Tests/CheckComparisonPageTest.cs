using CucumberCarsTests.Pages;
using CucumberCarsTests.Settings;
using CucumberCarsTests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CucumberCarsTests
{
    public class CheckComparisonPageTest : BaseTest
    {
        [Test]
        public void CheckCarsPrices()
        {
            var researchPage = new ResearchPage("Reseacrh page", ResearchPage.logoImageLocator, _webDriver);

            _webDriver.Navigate().GoToUrl(TestData.SitePath);
            Assert.IsTrue(researchPage.IsPageLoaded(), $"{researchPage.name} didn't load.");
            var firstCarCountSeating = researchPage.FindCarsAndSaveCarsTrimData(TestData.firstCarSearchCriterias);

            _webDriver.Navigate().GoToUrl(TestData.SitePath);
            Assert.IsTrue(researchPage.IsPageLoaded(), $"{researchPage.name} didn't load.");
            var secondCarCountSeating = researchPage.FindCarsAndSaveCarsTrimData(TestData.secondCarSearchCriterias);

            researchPage.toolBar.GoToResearchAndReviewsPage();
            Assert.IsTrue(researchPage.IsResearchPage(), $"{researchPage.name} this isn't Reseach Page.");

            researchPage.GoToCompareCars();
            var compareCarsPage = new CompareCarsPage("Compare cars page", CompareCarsPage.logoImageLocator, _webDriver);
            Assert.IsTrue(compareCarsPage.IsPageLoaded(), $"{compareCarsPage.name} didn't load.");
            compareCarsPage.SlectCarsAndGoToComparisonSelectedCars();
            compareCarsPage.CompareCarsSeatsCount(firstCarCountSeating, secondCarCountSeating);

            compareCarsPage.GoToCarPage(TestData.firstCarSearchCriterias);

            researchPage.IsCarPage(TestData.firstCarSearchCriterias);
            var carPrice = researchPage.GetCarPrice();

            _webDriver.Navigate().GoToUrl(TestData.SitePath);
            Assert.IsTrue(researchPage.IsPageLoaded(), $"{researchPage.name} didn't load.");
            researchPage.searchForm.FillSearchFormAndSearch();

            var carsForSalePage = new CarsForSalePage("Cars for sale page", ResearchPage.logoImageLocator, _webDriver);
            Assert.IsTrue(carsForSalePage.IsResultListNotEmpty(), $"Result list is empty.");

            carsForSalePage.AddNewSearchConditions();
            Assert.IsTrue(carsForSalePage.IsResultListNotEmpty(), $"Result list is empty.");

            var carPriceFromResultList = carsForSalePage.GetCarPriceFromResultList();
            Assert.IsTrue(StringUtils.IsFirstStringGreaterThenSecondString(carPrice, carPriceFromResultList),
                $"Car price form sale Page greater then car price from research Page.");
        }

        [Test]
        public void CheckComparisons()
        {
            var researchPage = new ResearchPage("Reseacrh page", ResearchPage.logoImageLocator, _webDriver);

            _webDriver.Navigate().GoToUrl(TestData.SitePath);
            Assert.IsTrue(researchPage.IsPageLoaded(), $"{researchPage.name} didn't load.");
            var firstCarCountSeating = researchPage.FindCarsAndSaveCarsTrimData(TestData.firstCarSearchCriterias);

            _webDriver.Navigate().GoToUrl(TestData.SitePath);
            Assert.IsTrue(researchPage.IsPageLoaded(), $"{researchPage.name} didn't load.");
            var secondCarCountSeating = researchPage.FindCarsAndSaveCarsTrimData(TestData.secondCarSearchCriterias);

            researchPage.toolBar.GoToResearchAndReviewsPage();
            Assert.IsTrue(researchPage.IsResearchPage(), $"{researchPage.name} this isn't Reseach Page.");

            researchPage.GoToCompareCars();
            var compareCarsPage = new CompareCarsPage("Compare cars page", CompareCarsPage.logoImageLocator, _webDriver);
            Assert.IsTrue(compareCarsPage.IsPageLoaded(), $"{compareCarsPage.name} didn't load.");
            compareCarsPage.SlectCarsAndGoToComparisonSelectedCars();
            compareCarsPage.CompareCarsSeatsCount(firstCarCountSeating, secondCarCountSeating);

        }
    }
}