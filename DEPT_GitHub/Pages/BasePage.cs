using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPT_GitHub.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

    }
}
