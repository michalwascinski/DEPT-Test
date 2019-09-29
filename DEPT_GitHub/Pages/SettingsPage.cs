using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPT_GitHub.Pages
{
    public class SettingsPage:BasePage
    {
        private IWebElement DeleteRepositoryButton => _driver.FindElement(By.XPath("//summary[contains(text(), 'Delete this repository')]"));
        private IWebElement RepositoryNameField => _driver.FindElement(By.XPath("(//input[@name='verify'])[3]"));
        private IWebElement ConfirmDeletionButton => _driver.FindElement(By.XPath("//*[contains(text(), 'delete this')]"));
 
        public SettingsPage(IWebDriver driver) : base(driver) { }

        internal LandingPage DeleteRepo(string repositoryName)
        {
            DeleteRepositoryButton.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@name='verify'])[3]")));
            RepositoryNameField.Click();
            RepositoryNameField.SendKeys(repositoryName);
            ConfirmDeletionButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()[contains(.,'successfully deleted')]]")));
            return new LandingPage(_driver);
        }
    }
}
