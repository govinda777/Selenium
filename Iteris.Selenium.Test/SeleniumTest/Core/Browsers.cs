using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;
using SeleniumCore = Facade.Selenium.Core;

namespace Selenium.Test.SeleniumTest.Core
{
    public class BrowserAttribute : DataAttribute
    {
        private SeleniumCore.ISelenium Browser { get; set; }

        public BrowserAttribute(Type browser)
        {
            if(browser == typeof(InternetExplorerDriver))
            {
                Browser = new SeleniumCore.Selenium(typeof(InternetExplorerDriver));
            }

            if (browser == typeof(FirefoxDriver))
            {
                Browser = new SeleniumCore.Selenium(typeof(FirefoxDriver));
            }

            if (browser == typeof(OperaDriver))
            {
                Browser = new SeleniumCore.Selenium(typeof(OperaDriver));
            }

            //if (browser == typeof(InternetExplorerDriver))
            //{
            //    Browser = new Selenium<InternetExplorerDriver>();
            //}

            //if (browser == typeof(InternetExplorerDriver))
            //{
            //    Browser = new Selenium<InternetExplorerDriver>();
            //}

            //if (browser == typeof(InternetExplorerDriver))
            //{
            //    Browser = new Selenium<InternetExplorerDriver>();
            //}


            //switch (browser.ToString())
            //{
            //    case internetExplorerDriver:
            //        Browser = new Selenium<InternetExplorerDriver>();
            //        break;
            //    case "Firefox 3.5":
            //        Browser = new DefaultSelenium("localhost", 4444, "*firefox", url);
            //        Browser.Start();
            //        break;
            //    case "Google Chrome":
            //        Browser = new DefaultSelenium("localhost", 4444, "*googlechrome", url);
            //        Browser.Start();
            //        break;
            //    case "Opera":
            //        Browser = new DefaultSelenium("localhost", 4444, "*opera", url);
            //        Browser.Start();
            //        break;
            //}
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest)
        {
            yield return new[] { Browser };
        }
    }
}
