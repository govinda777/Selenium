using Facade.Selenium.Infra.Helper.Browser;
using OpenQA.Selenium.Chrome;
using Xunit;
using SCore = Facade.Selenium.Core;
using System.Linq;

namespace Selenium.Test.Infra.Helper.Browser
{
    public class BrowserConfigTest
    {
        [Trait("GetBrowsersElement", "BrowserConfig")]
        [Fact]
        public void GetBrowsersElement()
        {
            // Arrange


            // Act
            var browser =  new BrowserConfig().GetBrowsersElement(typeof(ChromeDriver));

            // Assert
            Assert.True(browser.WebDriverType == typeof(ChromeDriver).Name);

        }

        [Trait("GetBrowser", "BrowserConfig")]
        [Fact]
        public void GetBrowser()
        {
            // Arrange


            // Act
            var browser = new BrowserConfig().GetBrowser(typeof(ChromeDriver));

            // Assert
            Assert.True(browser != null);

        }        
    }
}