using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;



namespace TFL.Pages
{
    public class EditpreferencesPage
    {

        IWebDriver _driver;

        public EditpreferencesPage(IWebDriver driver)

        {
            this._driver = driver;
        }
        IWebElement Editpreferencelink => _driver.FindElement(By.XPath("//*[@id=\"plan-a-journey\"]/div[3]/div[4]/button"));

        IWebElement Routesradiobutton => _driver.FindElement(By.CssSelector("#more-journey-options > div > fieldset > ul.stacked-fields.search-public-options.level-one.clearfix > li.show-me-list > " +
                                                                            "fieldset > div > div > div.form-control > label:nth-child(6)"));

        private readonly By UpdateJourney = By.CssSelector("#more-journey-options > div > fieldset > div.update-buttons-container.clearfix > div > input.primary-button.plan-journey-button");

        IWebElement UpdateJourneybutton => _driver.FindElement(UpdateJourney);

        public void editjourney()
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            //js.ExecuteScript("window.scrollBy(0, 500);");
            //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"plan-a-journey\"]/div[3]/div[4]/button")));
            Actions actions = new Actions(_driver);
            actions.MoveToElement(Editpreferencelink).Perform();
            Editpreferencelink.Click();            
        }

        public void selectleastwalking()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#more-journey-options > div > fieldset > ul.stacked-fields.search-public-options.level-one.clearfix > li.show-me-list > fieldset > div > div > div.form-control > label:nth-child(6)")));
            Routesradiobutton.Click();
        }        
        public void updateJourney()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollBy(0, 500);");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(UpdateJourney));
            UpdateJourneybutton.Click();
        }

    }

}
