using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPT_GitHub.Pages
{
    class RepositoryPage:BasePage
    {
        private IWebElement CreateNewFileLink => _driver.FindElement(By.LinkText("creating a new file"));
        private IWebElement FileNameField => _driver.FindElement(By.Name("filename"));
        private IWebElement CommitNewFileButton => _driver.FindElement(By.Id("submit-file"));
        private IWebElement SettingsButton => _driver.FindElement(By.XPath("//a[@href='/DEPT-testacc001/DeptTestRepo/settings']"));

        public RepositoryPage(IWebDriver driver) : base(driver) { }

        internal void AddReadmeFile()
        {
            CreateNewFileLink.Click();
            FileNameField.SendKeys("Readme.md");
            CommitNewFileButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Manage topics')]")));
        }

        internal SettingsPage GoToSettings()
        {
            SettingsButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Danger')]")));
            return new SettingsPage(_driver);
        }
    }
}
