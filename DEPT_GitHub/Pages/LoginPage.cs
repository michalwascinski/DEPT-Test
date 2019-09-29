using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPT_GitHub.Pages
{
    public class LoginPage:BasePage
    {
        private static string url = "https://github.com/login";

        private IWebElement UsernameField => _driver.FindElement(By.Id("login_field"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        private IWebElement SignInButton => _driver.FindElement(By.Name("commit"));

        public LoginPage(IWebDriver driver):base(driver) { }

        internal static LoginPage Goto(IWebDriver _driver)
        {
            _driver.Navigate().GoToUrl(url);
            Assert.AreEqual("Sign in to GitHub · GitHub", _driver.Title);
            return new LoginPage(_driver);
        }

        internal LandingPage LogIntoGithub(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            SignInButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[text()[contains(.,'New')]])[5]")));
            return new LandingPage(_driver);
        }
    }
}
