using OpenQA.Selenium;
using TestProject.Core.Extensions;

namespace TestProject.Pages
{
    public class LandingPage : BaseNavigationProvider
    {
        //Buttons
        private By LoginButton = By.ClassName("login");
        public By AccountButton = By.ClassName("account");
        //Tabs
        public By WomenTab = By.XPath(@"//*[@id=""block_top_menu""]/ul/li[1]/a");
        //Links
        public By TshitHyperlink = By.XPath(@"//*[@id=""block_top_menu""]/ul/li[1]/ul/li[1]/ul/li[1]/a");

        private By PageHeader = By.ClassName("cat-name");

        public LandingPage(IWebTest webTest) : base(webTest)
        {

        }
        public LoginPage ClickLoginButton()
        {
            LoginButton.ClickPageButton(WebDriver);
            return new LoginPage(Test);
        }
        public MyAccount LoginToApplication(string email = "TestUser@TestUser.ie", string password = "3YkBPukfdKwnMg")
        {
            ClickLoginButton()
                .EnterEmail(email)
                .EnterPassword(password)
                .ClickSubmit();
            return new MyAccount(Test);
        }
        public LandingPage CheckAccountUser(string user)
        {
            CheckElementText(AccountButton, user);
            return this;
        }
        public LandingPage NavigateToWomenTshirt()
        {
            WomenTab.HoverOverPageElement(WebDriver);
            TshitHyperlink.ClickPageButton(WebDriver);
            return this;
        }
        public LandingPage CheckHeader(string header)
        {
            CheckElementText(PageHeader, header);
            return this;
        }
    }
}
