using OpenQA.Selenium;

namespace ApplicationPage
{
   public class LoginPage
    {
        IWebDriver webDriver
        { get; set; }
        int timeout = 30;
        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public bool openLoginPage(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            return verifyLoginButton();
        }

        public void login(string username, string password)
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            By usernameElementById = By.Id("username");
            IWebElement usernameField = webDriver.FindElement(usernameElementById);
            functionLibrary.waitForElementVisible(usernameElementById, timeout);
            usernameField.SendKeys(username);
            By passwordFieldById = By.Id("password");
            IWebElement passwordField = webDriver.FindElement(passwordFieldById);
            functionLibrary.waitForElementVisible(passwordFieldById, timeout);
            passwordField.SendKeys(password);
            By loginButtonById = By.Id("login");
            IWebElement loginButton = webDriver.FindElement(loginButtonById);
            functionLibrary.waitForElementVisible(loginButtonById, timeout);
            loginButton.Click();
        }

        public bool verifyLoginButton()
        {
            FunctionLibrary functionLibrary = new FunctionLibrary(webDriver);
            By loginButtonById = By.Id("login");
            IWebElement loginButton = webDriver.FindElement(loginButtonById);
            functionLibrary.waitForElementVisible(loginButtonById, timeout);
            if (loginButton.Displayed)
                return true;
            else
                return false;

        }

    }
}
