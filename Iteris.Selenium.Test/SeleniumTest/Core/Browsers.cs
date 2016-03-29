using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Reflection;
using Selenium.Core;
using Selenium.Core.Interface;
using Xunit.Sdk;

namespace Selenium.Test.SeleniumTest.Core
{
    public class BrowserAttribute : DataAttribute
    {
        private ISelenium Browser { get; set; }

        public BrowserAttribute(Type browser)
        {
            if(browser == typeof(InternetExplorerDriver))
            {
                Browser = new Selenium.Core.Selenium(typeof(InternetExplorerDriver));
            }

            if (browser == typeof(FirefoxDriver))
            {
                Browser = new Selenium.Core.Selenium(typeof(FirefoxDriver));
            }

            if (browser == typeof(OperaDriver))
            {
                Browser = new Selenium.Core.Selenium(typeof(OperaDriver));
            }
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest)
        {
            yield return new[] { Browser };
        }
    }
}
