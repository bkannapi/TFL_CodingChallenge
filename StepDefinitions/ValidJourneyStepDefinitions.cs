using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TFL.Pages;
using TFL.Configuration;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace TFL.StepDefinitions
{
    [Binding]
    public class ValidJourneyStepDefinitions
    {
        IWebDriver _driver;
        ValidJourneyPage _page;
        EditpreferencesPage _editpreferences;
        public ValidJourneyStepDefinitions(IWebDriver driver)

        {
            this._driver = driver;
            _page=new ValidJourneyPage(_driver);
            _editpreferences =new EditpreferencesPage(_driver);
        }

        IWebElement TFLLogo => _driver.FindElement(By.CssSelector("#mainnav > div.top-row > div > div.logo > a > span.tfl-name"));
        IWebElement Cookie => _driver.FindElement(By.CssSelector("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll > strong"));
        IWebElement result => _driver.FindElement(By.CssSelector("#full-width-content > div > div:nth-child(7) > div > h2"));          

        IWebElement viewdetailsbutton => _driver.FindElement(By.CssSelector("#option-1-content > div.journey-details > div.price-and-details.clearfix > div.clearfix > button.secondary-button.show-detailed-results.view-hide-details"));

        IWebElement stairs => _driver.FindElement(By.CssSelector("#option-1-content > div.journey-details > div:nth-child(3) > div > div.details > div > div > div > a.up-stairs.tooltip-container"));

        IWebElement lift => _driver.FindElement(By.CssSelector("#option-1-content > div.journey-details > div:nth-child(3) > div > div.details > div > div > div > a.up-lift.tooltip-container"));

        [Given(@"Load the TFL site on chrome browser")]
        public void GivenLoadTheTFLSiteOnChromeBrowser()
        {
            _driver.Navigate().GoToUrl(ReadConfig.WebUrl);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#mainnav > div.top-row > div > div.logo > a > span.tfl-name")));

            try
            {
                // Find and click the 'Accept Cookies' button if present
                IWebElement cookieButton = _driver.FindElement(By.CssSelector("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
                cookieButton.Click();

                // Wait briefly for the overlay to potentially disappear
                //Thread.Sleep(1000);

                // Forcefully hide the overlay using JavaScript
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("document.getElementById('cb-cookieoverlay').style.display = 'none';");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cookie button not found.");
            }

            // Validate page title
            string actualTitle = _driver.Title;
            string expectedTitle = "Plan a journey - Transport for London";
            Assert.AreEqual(actualTitle, expectedTitle, "Title does not match");
        }

        [When(@"I enter LeicesterSquare in From textbox")]
        public void WhenIEnterLeicesterSquareInFromTextbox()
        {
            _page.Journeyfrom("Lei");
        }

        [When(@"I enter CoventGarden in To textbox")]
        public void WhenIEnterCoventGardenInToTextbox()
        {
            _page.Journeyto("Cov");
        }

        [Then(@"I click Plan my Journey button")]
        public void ThenIClickPlanMyJourneyButton()
        {
            _page.planmyjourney();
        }

        [Then(@"I should be shown with releavnt result")]
        public void ThenIShouldBeShownWithReleavntResult()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#full-width-content > div > div:nth-child(7) > div > h2")));
            string resultTitle = result.Text;
            // Assert that the result title contains the expected substring
            Assert.IsTrue(resultTitle.Contains("Walking and cycling"), "The result title does not contain 'Walking and cycling'.");
            Thread.Sleep(5000);
        }

        [Then(@"I should Validate the result for both walking and cycling time\.")]
        public void ThenIShouldValidateTheResultForBothWalkingAndCyclingTime_()
        {
            // Retrieve cycling time
            string cyclingTime = _page.GetCyclingTime();
            Console.WriteLine($"Cycling Time: {cyclingTime}");  // Log cycling time

            // Retrieve walking time
            string walkingTime = _page.GetWalkingTime();
            Console.WriteLine($"Walking Time: {walkingTime}");  // Log walking time
                        
            Assert.IsNotNull(cyclingTime, "Cycling time should not be null.");
            Assert.IsNotNull(walkingTime, "Walking time should not be null.");
        }

        [When(@"I select edit preference link in the journey result")]
        public void WhenISelectEditPreferenceLinkInTheJourneyResult()
        {
            _editpreferences.editjourney();
        }

        [When(@"I select routes with least walking")]
        public void WhenISelectRoutesWithLeastWalking()
        {
            _editpreferences.selectleastwalking();
        }

        [When(@"click update journey button")]
        public void WhenClickUpdateJourneyButton()
        {
            _editpreferences.updateJourney();
        }

        [Then(@"the TFL site should present relevant result")]
        public void ThenTheTFLSiteShouldPresentRelevantResult()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#option-1-content > div.journey-details > div.price-and-details.clearfix > div.clearfix > button.secondary-button.show-detailed-results.view-hide-details")));

        }

        [When(@"I click view details button")]
        public void WhenIClickViewDetailsButton()
        {
            viewdetailsbutton.Click();
        }

        [Then(@"I should be shown and verify the access information")]
        public void ThenIShouldBeShownAndVerifyTheAccessInformation()
        {
            string stairstext = stairs.Text;
            string lifttext = lift.Text;

            Console.WriteLine("Has stairs", stairstext);

            Console.WriteLine("Has lift", lifttext);
        }


    }
}
