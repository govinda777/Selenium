using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Configuration;

namespace Iteris.Selenium.Core.Selemiun
{
    public class Navigation<T> : Base<T>, IDisposable where T : IWebDriver
    {
        public Navigation()
            : base()
        {
            Execute(() =>
            {
                driver.Manage().Window.Maximize();
            });
        }

        public void CloseWebBrowser()
        {
            Execute(() =>
            {
                driver.Navigate().GoToUrl("about:blank");
            });
        }

        public void OpenUrl(string url)
        {
            ExecuteWithEvidence("Abrindo url", () =>
            {
                driver.Navigate().GoToUrl(url);
            });
        }

        public string GetCurrentUrl()
        {
            return Execute<string>(() =>
            {
                return driver.Url;
            });
        }

        public void NavigateBack()
        {
            ExecuteWithEvidence("Voltando página", () =>
            {
                driver.Navigate().Back();
            });
        }

        public void Dispose()
        {
            CloseWebBrowser();
        }
    }
}
