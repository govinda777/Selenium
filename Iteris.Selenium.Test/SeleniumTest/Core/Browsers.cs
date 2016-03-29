using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;
using SeleniumCore = Facade.Selenium.Infra;

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
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest)
        {
            yield return new[] { Browser };
        }
    }
}
