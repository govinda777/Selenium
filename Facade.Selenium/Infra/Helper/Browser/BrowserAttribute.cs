using System;
using System.Collections.Generic;
using System.Reflection;
using Facade.Selenium.Core.Interface;
using Xunit.Sdk;

namespace Facade.Selenium.Infra.Helper.Browser
{
    public class BrowserAttribute : DataAttribute
    {
        private ISelenium Browser { get; set; }
        
        public BrowserAttribute(Type browser)
        {
            Browser = new BrowserConfig().GetBrowser(browser);
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest)
        {
            yield return new[] { Browser };
        }

      
    }
}
