using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TFL.Pages;
using NUnit.Framework;

namespace TFL.StepDefinitions
{
    [Binding]
    public class VerifyinvalidjourneyStepDefinitions
    {
        IWebDriver _driver;
        ValidJourneyPage _page;
        ValidJourneyStepDefinitions _Validjourney;
        IWebElement FromTextBox => _driver.FindElement(By.Id("InputFrom"));
        IWebElement ToTextBox => _driver.FindElement(By.CssSelector("#InputTo"));
        IWebElement Invalidjrnerrmsg => _driver.FindElement(By.CssSelector("#full-width-content > div > div:nth-child(8) > div > div > ul > li"));
        
        public VerifyinvalidjourneyStepDefinitions(IWebDriver driver)
        {
            this._driver = driver;
            _page = new ValidJourneyPage(_driver);
            _Validjourney=new ValidJourneyStepDefinitions(_driver);
        }

        [Given(@"load the TFL site")]
        public void GivenLoadTheTFLSite()
        {
            _Validjourney.GivenLoadTheTFLSiteOnChromeBrowser();
        }


        [When(@"I enter inlvald location in From field")]
        public void WhenIEnterInlvaldLocationInFromField()
        {
            FromTextBox.SendKeys("6775");
        }


        [When(@"I enter invalid location in To field")]
        public void WhenIEnterInvalidLocationInToField()
        {
            ToTextBox.SendKeys("67898");
        }


        [Then(@"I should be shown with error message")]
        public void ThenIShouldBeShownWithErrorMessage()
        {
            _page.planmyjourney();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#full-width-content > div > div:nth-child(8) > div > div > ul > li")));
            string errormessage=Invalidjrnerrmsg.Text;
            Assert.That(errormessage.Contains("Journey planner could not find any results to your search. Please try again"));
            Console.WriteLine("Invalid Location Error Meaage",errormessage);
        }

    }
}
