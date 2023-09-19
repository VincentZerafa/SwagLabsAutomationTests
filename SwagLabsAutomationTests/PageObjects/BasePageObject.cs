using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SwagLabsAutomationTests.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;

namespace SwagLabsAutomationTests.PageObjects
{
    public class BasePageObject : IDisposable
    {
        //The Selenium web driver to automate the browser
        public IWebDriver Driver { get; set; }
        public StringFormatter StringFormatter { get; set; }

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 10;

        public BasePageObject()
        {
            Driver = new ChromeDriver();
            StringFormatter = new StringFormatter();
        }

        public WebDriverWait Wait()
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        }

        public bool WaitUntilPageLoad(string redirectUrl)
        {
            return Wait().Until(ExpectedConditions.UrlMatches(redirectUrl));
        }

        public IWebElement WaitUntilVisible(string elementId)
        {
            return Wait().Until(ExpectedConditions.ElementIsVisible(By.Id(elementId)));
        }

        public void Dispose()
        {
            Driver.Close();
            Driver.Dispose();
        }
    }
}
