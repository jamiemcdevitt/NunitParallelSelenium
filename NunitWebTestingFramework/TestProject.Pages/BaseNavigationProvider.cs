using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestProject.Core.Extensions;
using TestProject.Core.Utilities;

namespace TestProject.Pages
{
    public abstract class BaseNavigationProvider
    {
        protected IWebTest Test;
        public IWebDriver WebDriver; 
        public BaseNavigationProvider(IWebTest webTest)
        {
            Test = webTest;
            WebDriver = Test.BaseWebDriver;
            PageFactory.InitElements(WebDriver, this);
        }

        public LandingPage NavigateToLandingPage()
        {
            WebDriver.Navigate().GoToUrl(AppConfig.InitUrl);
            WebDriver.WaitForPageLoad();
            return new LandingPage(Test);
        }
        public BaseNavigationProvider CheckElementText(By pageElement, string expectedText)
        {
            var actualText = pageElement.Text(WebDriver);
            Assert.AreEqual(expectedText, actualText, $"Expected Page Element: '{expectedText}' but was: '{actualText}'");
            return this;
        }
    }
}
