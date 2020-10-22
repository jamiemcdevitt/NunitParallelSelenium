using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Extensions;

namespace TestProject.Pages
{
    public class MyAccount : BaseNavigationProvider
    {
        private By HomeButton = By.Id("my-account");
        private By PageHeader = By.ClassName("page-heading");
        public MyAccount(IWebTest webTest) : base(webTest)
        {

        }
        public LandingPage ClickHomeButton()
        {
            HomeButton.ClickPageButton(WebDriver);
            return new LandingPage(Test);
        }
        public MyAccount CheckHeader(string header)
        {
            CheckElementText(PageHeader, header);
            return this;
        }
    }
}
