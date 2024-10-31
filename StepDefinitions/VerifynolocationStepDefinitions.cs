using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TFL.Pages;

namespace TFL.StepDefinitions
{
    [Binding]
    public class VerifynolocationStepDefinitions
    {
        IWebDriver _driver;
        ValidJourneyPage _page;
        ValidJourneyStepDefinitions _Validjourney;
       

        public VerifynolocationStepDefinitions(IWebDriver driver)

        {
            this._driver = driver;
            _page = new ValidJourneyPage(_driver);
            _Validjourney = new ValidJourneyStepDefinitions(_driver);
        }

        IWebElement FromTextBox => _driver.FindElement(By.Id("InputFrom"));
        IWebElement ToTextBox => _driver.FindElement(By.CssSelector("#InputTo"));
        IWebElement nolocationfromerrmsg => _driver.FindElement(By.CssSelector("#InputFrom-error"));
        IWebElement nolocationtoerrmsg => _driver.FindElement(By.CssSelector("#InputTo-error"));

        [Given(@"Loading the TFL site")]
        public void GivenLoadingTheTFLSite()
        {
            _Validjourney.GivenLoadTheTFLSiteOnChromeBrowser();
        }

                
        [When(@"I hit plan my journey button without locations in fromto fields")]
        public void WhenIHitPlanMyJourneyButtonWithoutLocationsInFromtoFields()
        {
            _page.planmyjourney();
        }


        [Then(@"I should be shown with relevant error message")]
        public void ThenIShouldBeShownWithRelevantErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#InputFrom-error")));
            string frmerrormessage = nolocationfromerrmsg.Text;
            string toerrormessage= nolocationtoerrmsg.Text;
            Assert.That(frmerrormessage.Contains("From field is required"));
            Assert.That(toerrormessage.Contains("To field is required"));           
        }
    }
}
