using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using Selenium.Core.Interface;
using Selenium.Infra.ReadConfig;
using Xunit.Sdk;
using System.Linq;

namespace Selenium.Infra.Helper.Test
{
    public class BrowserAttribute : DataAttribute
    {
        private ISelenium Browser { get; set; }
        
        public BrowserAttribute(Type browser)
        {
            
        }

        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest)
        {
            yield return new[] { Browser };
        }

      
    }
}
