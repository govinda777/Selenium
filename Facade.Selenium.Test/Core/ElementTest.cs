using Xunit;
using Facade.Selenium.Core;
using Facade.Selenium.Infra.Helper.Browser;
using OpenQA.Selenium.Chrome;
using Facade.Selenium.Core.Interface;
using OpenQA.Selenium.Firefox;

namespace Selenium.Test.Core
{
    [Trait("Element", "EL")]
    public class ElementTest
    {
        private readonly Facade.Selenium.Core.Selenium _selenium;

        [Theory]
        [Browser(typeof(FirefoxDriver))]
        [Browser(typeof(ChromeDriver))]
        public void Teste1(ISelenium browser)
        {
            browser.Initialize();
        }

        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void Teste2(ISelenium browser)
        {
            browser.Initialize();
        }
    }
}
