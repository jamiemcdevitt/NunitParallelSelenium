using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TestProject.Core;
using TestProject.Core.Extensions;
using TestProject.Pages;

namespace NunitWebTestingFramework.Base
{
    public sealed class AutomationBase : IWebTest
    {
        public IWebDriver BaseWebDriver { get; private set; }
        private readonly DriverBase _driverBase;
        public AutomationBase(string browser)
        {
            _driverBase = new DriverBase(browser);
        }
        public BaseNavigationProvider StartBrowser()
        {
            BaseWebDriver = _driverBase.GetDriver();
            return new LandingPage(this);
        }
        private void DisposeWebDriverInstance()
        {
            if (BaseWebDriver.IsNotNull())
            {
                BaseWebDriver.Quit();
                BaseWebDriver.Dispose();
                BaseWebDriver = null;
            }
        }
        public void Dispose()
        {
            DisposeWebDriverInstance();
            GC.SuppressFinalize(this);
        }
        [TearDown]
        public void AfterTest()
        {
        }
    }
}
