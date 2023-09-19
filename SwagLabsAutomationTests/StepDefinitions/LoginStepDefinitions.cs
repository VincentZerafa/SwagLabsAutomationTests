using OpenQA.Selenium.Support.UI;
using SwagLabsAutomationTests.PageObjects;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;

namespace SwagLabsAutomationTests.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private LoginPageObject _loginPageObject;

        public LoginStepDefinitions()
        {
            _loginPageObject = new LoginPageObject();
        }

        [Given(@"user redirected to login page")]
        public void GivenUserRedirectedToLoginPage()
        {
            _loginPageObject.RedirectToLoginPage();
        }

        [Given(@"user inputs username ""([^""]*)""")]
        [When(@"user inputs username ""([^""]*)""")]
        public void WhenUserInputsUsername(string username)
        {
            _loginPageObject.EnterUsername(username);
        }

        [Given(@"user inputs password ""([^""]*)""")]
        [When(@"user inputs password ""([^""]*)""")]
        public void WhenUserInputsPassword(string password)
        {
            _loginPageObject.EnterPassword(password);
        }

        [Given(@"the login button is clicked")]
        [When(@"the login button is clicked")]
        public void WhenTheLoginButtonIsClicked()
        {
            _loginPageObject.ClickLogin();
        }

        [Given(@"the user should be redirected to page ""([^""]*)""")]
        [Then(@"the user should be redirected to page ""([^""]*)""")]
        public void ThenTheUserShouldBeRedirectedToTheCatalogPage(string expectedRedirectUrl)
        {
            _loginPageObject.WaitUntilPageLoad(expectedRedirectUrl).Should().Be(true);
        }

        [Then(@"the user stays on the login page ""([^""]*)""")]
        public void ThenTheUserStaysOnTheLoginPage(string loginPageUrl)
        {
            _loginPageObject.Driver.Url.Should().Be(loginPageUrl);
        }

        [Then(@"the user should displayed with an error message ""([^""]*)""")]
        public void ThenTheUserShouldDisplayedWithAnErrorMessage(string errorMessage)
        {
            IWebElement errorMessageElement = _loginPageObject.FindErrorMessage();

            errorMessageElement.Text.Should().Be(errorMessage);
        }

        [When(@"user clicks on hamburger menu")]
        public void WhenUserClicksOnHamburgerMenu()
        {
            _loginPageObject.ClickHamburgerMenu();
        }

        [When(@"user clicks on logout")]
        public void WhenUserClicksOnLogout()
        {
            _loginPageObject.WaitUntilVisible("logout_sidebar_link");
            _loginPageObject.ClickLogout();
        }

        [AfterScenario("login")]
        public void AfterScenario()
        {
            _loginPageObject.Dispose();
        }
    }
}
