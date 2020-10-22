using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace TestProject.Core
{
    public sealed class DriverBase
    {
        private string _browserName;

        public DriverBase(string browser)
        {
            _browserName = browser.ToLower();
        }

        public IWebDriver GetDriver()
        {
            var driver = GetLocalDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            return driver;
        }
        private IWebDriver GetLocalDriver()
        {
            switch (_browserName)
            {
                case "chrome":
                    var chromOptions = new ChromeOptions();
                    return new ChromeDriver(chromOptions);
                case "microsoftedge":
                    var edgeOptions = new EdgeOptions();
                    return new EdgeDriver(edgeOptions);
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    return new FirefoxDriver(firefoxOptions);
                case "internet explorer":
                    var ieOptions = new InternetExplorerOptions();
                    return new InternetExplorerDriver(ieOptions);
                default:
                    throw new InvalidOperationException("Driver type not supported");
            }
        }
    }
}
