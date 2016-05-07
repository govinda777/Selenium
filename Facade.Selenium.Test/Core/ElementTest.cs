using Xunit;
using Facade.Selenium.Core;
using Facade.Selenium.Infra.Helper.Browser;
using OpenQA.Selenium.Chrome;
using Facade.Selenium.Core.Interface;
using OpenQA.Selenium.Firefox;
using SCore = Facade.Selenium.Core;
using OpenQA.Selenium;

namespace Selenium.Test.Core
{
    public class ElementTest
    {
        private readonly string _url = @"http://iteris.com.br/v2/";
        private readonly string _id = @"home-menu-links";
        private readonly string _idNotFound = @"wnveoiwevowçnioçnoilkn";
        private readonly string _name = @"description";
        private readonly string _nameNotFound = @"avndçsvnsçdvçsldvçl";
        private readonly string _class = @"seta-verde";
        private readonly string _classNotFound = @"avnlkasçvkalskvak";

        private SCore.Selenium _browser;

        public void Initialize(SCore.Selenium browser)
        {
            _browser = browser;

            _browser.Initialize();

            _browser.Navigation.OpenUrl(_url);
        }

        public void Dispose()
        {
            _browser.Navigation.CloseWebBrowser();
        }

        [Trait("FindElementById", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void FindElementById_InPage_ReturnsTheElement(SCore.Selenium browser)
        {
            // Arrange
            Initialize(browser);

            // Act
            var element = browser.Element.FindElementById(_id);

            // Assert
            Assert.True(element != null);
        }

        [Trait("FindElementById", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void FindElementById_InPage_ElementNotFound(SCore.Selenium browser)
        {
            // Arrange
            Initialize(browser);

            // Act
            var element = browser.Element.FindElementById(_idNotFound);

            // Assert
            Assert.True(element == null);
        }

        [Trait("FindElementByName", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void FindElementByName_InPage_ReturnsTheElement(SCore.Selenium browser)
        {
            // Arrange
            Initialize(browser);

            // Act
            var element = browser.Element.FindElementByName(_name);

            // Assert
            Assert.True(element != null);
        }

        [Trait("FindElementByName", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void FindElementByName_InPage_ElementNotFound(SCore.Selenium browser)
        {
            // Arrange
            Initialize(browser);

            // Act
            var element = browser.Element.FindElementByName(_nameNotFound);

            // Assert
            Assert.True(element == null);
        }

        [Trait("FindElementByClassName", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void FindElementByClassName_InPage_ReturnsTheElement(SCore.Selenium browser)
        {
            // Arrange
            Initialize(browser);

            // Act
            var element = browser.Element.FindElementByClassName(_class);

            // Assert
            Assert.True(element != null);
        }

        [Trait("FindElementByClassName", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void FindElementByClassName_InPage_ElementNotFound(SCore.Selenium browser)
        {
            // Arrange
            Initialize(browser);

            // Act
            var element = browser.Element.FindElementByClassName(_classNotFound);

            // Assert
            Assert.True(element == null);
        }

        [Trait("FindElement", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void FindElement_InPage_ReturnsTheElement(SCore.Selenium browser)
        {
            // Arrange
            var id = By.Id(_id);
            Initialize(browser);

            // Act
            var element = browser.Element.FindElement(id);

            // Assert
            Assert.True(element != null);
        }


        [Trait("FindElement", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void FindElement_InPage_ElementNotFound(SCore.Selenium browser)
        {
            // Arrange
            var id = By.Id(_idNotFound);
            Initialize(browser);

            // Act
            var element = browser.Element.FindElement(id);

            // Assert
            Assert.True(element == null);
        }


        [Trait("Submit", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void Submit(SCore.Selenium browser)
        {
            
        }

        [Trait("Click", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void Click(SCore.Selenium browser)
        {
            
        }

        [Trait("SendKeys", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void SendKeys(SCore.Selenium browser)
        {
            
        }

        [Trait("GetAttribute", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void GetAttribute(SCore.Selenium browser)
        {
            
        }

        [Trait("GetValue", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void GetValue(SCore.Selenium browser)
        {
            
        }

        [Trait("SelectDropDownByValue", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void SelectDropDownByValue(SCore.Selenium browser)
        {
            
        }

        [Trait("SelectDropDownByText", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void SelectDropDownByText(SCore.Selenium browser)
        {
            
        }
    }
}
