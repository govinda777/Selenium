using System;
using Facade.Selenium.Infra;
using Facade.Selenium.Infra;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Xunit.Extensions;
using Selenium.Test.SeleniumTest.Core;
using System.Collections.Generic;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using SeleniumCore = Facade.Selenium.Infra;
using System.Collections;

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
        
        public static IEnumerable<object> Browsers
        {
            get
            {
                var result = new [] {
                                    new [] { new SeleniumCore.Selenium(typeof(InternetExplorerDriver)) },
                                    new [] { new SeleniumCore.Selenium(typeof(FirefoxDriver)) },
                                    new [] { new SeleniumCore.Selenium(typeof(OperaDriver)) }
                                };

                yield return result;
            }
        }

        [Theory]
        [Browser(typeof(FirefoxDriver))]
        [Browser(typeof(InternetExplorerDriver))]
        [Browser(typeof(OperaDriver))]
        public void FindElementByIdTest(SeleniumCore.Selenium selenium)
        {
            selenium.Initialize();
        }

        [Theory]
        [ClassData(typeof(FibonacciTestSource))]
        public void Test_List_Browser(SeleniumCore.Selenium selenium)
        {
            selenium.Initialize();
        }

    }

    public class FibonacciTestSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new SeleniumCore.Selenium(typeof(InternetExplorerDriver)) };
            yield return new object[] { new SeleniumCore.Selenium(typeof(FirefoxDriver)) };
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
