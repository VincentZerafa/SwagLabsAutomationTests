using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsAutomationTests.PageObjects
{
    public class LoginPageObject : BasePageObject
    {
        private const string LoginPageUrl = "https://www.saucedemo.com/";

        public LoginPageObject() : base()
        {
        }

        //Finding elements by ID
        private IWebElement _usernameField => Driver.FindElement(By.Id("user-name"));
        private IWebElement _passwordField => Driver.FindElement(By.Id("password"));
        private IWebElement _loginButton => Driver.FindElement(By.Id("login-button"));
        private IWebElement _hamburgerMenu => Driver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement _logoutLink => Driver.FindElement(By.Id("logout_sidebar_link"));

        public void RedirectToLoginPage()
        {
            Driver.Navigate().GoToUrl(LoginPageUrl);
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }

        public void EnterUsername(string username)
        {
            //Clear text box
            _usernameField.Clear();
            //Enter text
            _usernameField.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            //Clear text box
            _passwordField.Clear();
            //Enter text
            _passwordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            //Click the login button
            _loginButton.Click();
        }

        public void ClickHamburgerMenu()
        {
            //Click the login button
            _hamburgerMenu.Click();
        }

        public void ClickLogout()
        {
            //Click the login button
            _logoutLink.Click();
        }

        public IWebElement FindErrorMessage()
        {
            return Driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));
        }
    }

}
