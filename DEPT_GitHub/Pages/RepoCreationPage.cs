using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPT_GitHub.Pages
{
    class RepoCreationPage:BasePage
    {
        private IWebElement RepositoryNameField => _driver.FindElement(By.Id("repository_name"));
        private IWebElement CreateRepositoryButton => _driver.FindElement(By.XPath("//button[contains(text(), 'Create repository')]"));
        private IWebElement DescriptionField => _driver.FindElement(By.Id("repository_description"));

        public RepoCreationPage(IWebDriver driver) : base(driver) { }

        internal RepositoryPage CreateNewRepoWithReadMe(string repositoryName)
        {
            RepositoryNameField.SendKeys(repositoryName);
            DescriptionField.SendKeys("Creating repository" + repositoryName);
            CreateRepositoryButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'creating a new file')]")));
            return new RepositoryPage(_driver);
        }
    }
}
