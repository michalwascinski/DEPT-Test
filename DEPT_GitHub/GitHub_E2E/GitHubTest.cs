using System;
using AutomationUtils;
using DEPT_GitHub.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DEPT_GitHub
{
    [TestClass]
    public class GitHubTest
    {
        private string testAccLogin = "michal.wascinski86+DEPTtest001@gmail.com";
        private string testAccPassword = "Q@testing1!";
        private string repositoryName = "DeptTestRepo";

        private IWebDriver _driver;
        private LoginPage loginPage;
        private LandingPage landingPage;
        private SettingsPage settingsPage;
        private RepositoryPage repositoryPage;
        private RepoCreationPage repoCreationPage;

        [TestInitialize]
        public void BeforeHook()
        {
            var factory = new WebDriverFactory();
            _driver = factory.Create(BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void CreateAndDeleteRepo()
        {
            loginPage = LoginPage.Goto(_driver);
            landingPage = loginPage.LogIntoGithub(testAccLogin, testAccPassword);
            repoCreationPage = landingPage.StartRepoCreation();
            repositoryPage = repoCreationPage.CreateNewRepoWithReadMe(repositoryName);
            repositoryPage.AddReadmeFile();
            settingsPage = repositoryPage.GoToSettings();
            landingPage = settingsPage.DeleteRepo(repositoryName);
            Assert.IsFalse(landingPage.IsRepoPresent(repositoryName));
        }

        [TestCleanup]
        public void AfterHook()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
