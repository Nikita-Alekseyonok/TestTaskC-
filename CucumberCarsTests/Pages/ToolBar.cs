using CucumberCarsTests.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CucumberCarsTests.Pages
{
    public class ToolBar:BasePage
    {
        public ToolBar(string name, By unique_element_locator, IWebDriver webdriver) : base(name, unique_element_locator, webdriver)
        {
        }

        private By researchAndReviewsButtonLocator = By.XPath("//a[@data-linkname='header-research']");

        public void GoToResearchAndReviewsPage() 
        {
            var ResearchAndReviewsButton = new Button(webdriver, "ResearchAndReviews_Button", researchAndReviewsButtonLocator);
            ResearchAndReviewsButton.ClickOnElement();

        }

    }
}
