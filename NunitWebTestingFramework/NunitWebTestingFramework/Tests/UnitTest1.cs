using NUnit.Framework;
using NunitWebTestingFramework.Base;
using TestProject.Core.Utilities;

namespace NunitWebTestingFramework.Tests
{
    [TestFixtureSource(typeof(TextFixtureArgs))]
    public class ChromeTesting
    {
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void ValidateMyAccountPage()
        {
            using (var testBase = new AutomationBase("chrome"))
            {
                testBase.
                StartBrowser()
                .NavigateToLandingPage()
                .LoginToApplication()
                .CheckHeader("MY ACCOUNT");
            }
        }
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void CheckAccountButtonUserDetails()
        {
            using (var testBase = new AutomationBase("chrome"))
            {
                testBase.
                StartBrowser()
                .NavigateToLandingPage()
                .LoginToApplication()
                .ClickHomeButton()
                .CheckAccountUser("TestUserFirstName TestUserLastName");
            }
        }
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void ValidateWomenTshit()
        {
            using (var testBase = new AutomationBase("chrome"))
            {
                testBase.
                StartBrowser()
                .NavigateToLandingPage()
                .NavigateToWomenTshirt()
                .CheckHeader("T-SHIRTS ");
            }
        }
    }
}