using AutomationUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUtils
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType type)
        {
            switch (type)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser configured");
            }
        }

        public IWebDriver GetChromeDriver()
        {
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
    }
}
