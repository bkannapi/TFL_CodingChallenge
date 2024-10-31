using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TFL.Pages
{
    public class ValidJourneyPage
    {
        IWebDriver _driver;
        
        public ValidJourneyPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        IWebElement FromTextBox => _driver.FindElement(By.Id("InputFrom"));
        IReadOnlyCollection<IWebElement> AutoSuggestionFrom => _driver.FindElements(By.ClassName("tt-suggestion"));
        IWebElement ToTextBox => _driver.FindElement(By.CssSelector("#InputTo"));
        IWebElement Planjourneybutton => _driver.FindElement(By.CssSelector("#plan-journey-button"));
        IWebElement Cycling => _driver.FindElement(By.CssSelector("#full-width-content > div > div:nth-child(7) > div > div.journey-row-container.left-journey-options > a.journey-box.cycling"));
        IWebElement Walking => _driver.FindElement(By.CssSelector("#full-width-content > div > div:nth-child(7) > div > div.journey-row-container.left-journey-options > a.journey-box.walking"));


        public void Journeyfrom(string partialText)
        {

            FromTextBox.Clear();
            FromTextBox.SendKeys(partialText);            
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", FromTextBox, partialText);
            
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].dispatchEvent(new Event('keyup'));", FromTextBox);
            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("tt-suggestion")));

            var suggestions = _driver.FindElements(By.ClassName("tt-suggestion"));
            foreach (var suggestion in suggestions)
            {
                IWebElement stopName = suggestion.FindElement(By.ClassName("stop-name"));
                if (stopName.Text.Contains("Leicester Square Underground Station"))
                {
                    stopName.Click(); 
                    break;
                }
            }
            
        }

        public void Journeyto(string partialText)
        {
            
            ToTextBox.Clear();
            ToTextBox.SendKeys(partialText);            
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = arguments[1];", ToTextBox, partialText);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].dispatchEvent(new Event('keyup'));", ToTextBox);            
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("tt-suggestion")));

            var suggestions = _driver.FindElements(By.ClassName("tt-suggestion"));
            foreach (var suggestion in suggestions)
            {
                IWebElement stopName = suggestion.FindElement(By.ClassName("stop-name"));
                if (stopName.Text.Contains("Covent Garden Underground Station"))
                {
                    stopName.Click(); 
                    break;
                }
            }
        }
        public void planmyjourney()
        {

            Planjourneybutton.Click();
        }

        public string GetCyclingTime()
        {
            return Cycling.Text;
        }

        public string GetWalkingTime()
        {

            return Walking.Text;
        }


    }
}
