using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using TFL.Configuration;
using Microsoft.Extensions.Configuration;

namespace TFL.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
            LoadConfiguration();
        }

        [BeforeTestRun]
        public static void BeforeHomePageFeature(IObjectContainer _container)
        {
           
            string browser = "Chrome"; 

            IWebDriver driver = null;

            if (browser.Equals("Chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browser.Equals("Firefox", StringComparison.OrdinalIgnoreCase))
            {
                driver = new FirefoxDriver();
            }
            else if (browser.Equals("Edge", StringComparison.OrdinalIgnoreCase))
            {
                driver = new EdgeDriver();
            }
            else
            {
                throw new NotSupportedException($"Browser '{browser}' is not supported.");
            }

            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
            LoadConfiguration();

        }

        [AfterTestRun]
        public static void AfterFeature(IObjectContainer _container)
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
        }

        private static void LoadConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("Appsettings.Environments.json", optional: false, reloadOnChange: true)
            .Build();

            var _environmentConfig = config.Get<EnvironmentConfig>();
            ReadConfig.WebUrl = _environmentConfig.WebUrl;
            

        }
    }
}