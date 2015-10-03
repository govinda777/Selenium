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
    public class Navigation : Base, IDisposable
    {
        public Navigation()
            : base()
        {
            Execute(() =>
            {
                driverIe.Manage().Window.Maximize();
            });
        }

        public void CloseWebBrowser()
        {
            Execute(() =>
            {
                driverIe.Navigate().GoToUrl("about:blank");
            });
        }

        public void OpenUrl(string url)
        {
            ExecuteWithEvidence("Abrindo url", () =>
            {
                driverIe.Navigate().GoToUrl(url);
            });
        }

        public string GetCurrentUrl()
        {
            return Execute<string>(() =>
            {
                return driverIe.Url;
            });
        }

        public void NavigateBack()
        {
            ExecuteWithEvidence("Voltando página", () =>
            {
                driverIe.Navigate().Back();
            });
        }

        public void Dispose()
        {
            CloseWebBrowser();
        }
    }
}
