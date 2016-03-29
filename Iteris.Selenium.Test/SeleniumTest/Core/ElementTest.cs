using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Xunit.Extensions;
using System.Collections.Generic;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using System.Collections;
using Selenium.Infra.Helper.Test;

namespace Facade.Selenium.Test.SeleniumTest.Core
{
    public class ElementTest
    {
        const string ID_ELEMENT = "usuario";        
        const string NAME_ELEMENT = "user";
        const string CLASS_ELEMENT = "cor9";
        const string CLASS_ELEMENT_BTN = "buttonSubmit";
        public string driverServerDirectory;
        
        public ElementTest()
        {

        }
        
        [Trait("Teste123", "CI")]
        [Theory]
        [Browser(typeof(FirefoxDriver))]
        [Browser(typeof(ChromeDriver))]
        public void FindElementByIdTest(global::Selenium.Core.Selenium selenium)
        {
            selenium.Initialize();
            selenium.Navigation.CloseWebBrowser();
        }

        [Trait("TesteABC", "CI")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void Test_List_Browser(global::Selenium.Core.Selenium selenium)
        {
            selenium.Initialize();
            selenium.Navigation.CloseWebBrowser();
        }
    }
}
