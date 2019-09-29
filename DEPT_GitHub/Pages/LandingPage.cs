using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPT_GitHub.Pages
{
    public class LandingPage:BasePage
    {
        private IWebElement CreateNewRepoButton => _driver.FindElement(By.XPath("(//*[text()[contains(.,'New')]])[5]"));

        public LandingPage(IWebDriver driver) : base(driver) { }

        internal RepoCreationPage StartRepoCreation()
        {
            CreateNewRepoButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("repository_auto_init")));
            return new RepoCreationPage(_driver);
        }

        internal bool IsRepoPresent(string repositoryName)
        {
            if(_driver.FindElements(By.XPath($"//*[contains(text(), '{repositoryName}')]")).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
