using OpenQA.Selenium;
using TestProject.Core.Extensions;

namespace TestProject.Pages
{
    public class LoginPage : BaseNavigationProvider
    {
        private By EmailAddressTextBox = By.Id("email");
        private By PasswordTextBox = By.Id("passwd");
        private By LoginButton = By.Id("SubmitLogin");
        public LoginPage(IWebTest webTest) : base(webTest)
        {

        }

        public LoginPage EnterEmail(string emailText)
        {
            EmailAddressTextBox.EnterText(emailText, WebDriver);
            return this;
        }
        public LoginPage EnterPassword(string passwordText)
        {
            PasswordTextBox.EnterText(passwordText, WebDriver);
            return this;
        }
        public LoginPage ClickSubmit()
        {
            LoginButton.ClickPageButton(WebDriver);
            return this;
        }
    }
}
