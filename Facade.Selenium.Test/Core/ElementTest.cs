using Xunit;
using Facade.Selenium.Core;
using Facade.Selenium.Infra.Helper.Browser;
using OpenQA.Selenium.Chrome;
using Facade.Selenium.Core.Interface;
using OpenQA.Selenium.Firefox;
using SCore = Facade.Selenium.Core;
using OpenQA.Selenium;
using Facade.Selenium.Infra.Helper;
using System;

namespace Selenium.Test.Core
{
    public class ElementTest : IDisposable
    {
        private readonly string _url = @"http://iteris.com.br/v2/";
        private readonly string _url2 = @"https://www.microsoft.com/pt-br/account";
        private readonly string _elementId = @"home-menu-links";
        private readonly string _elementIdNotFound = @"wnveoiwevowçnioçnoilkn";
        private readonly string _button = @"button-blue-16";
        private readonly string _buttonNotFound = @"svsmçldvmçsldv";
        private readonly string _name = @"description";
        private readonly string _nameNotFound = @"avndçsvnsçdvçsldvçl";
        private readonly string _class = @"seta-verde";
        private readonly string _classNotFound = @"avnlkasçvkalskvak";

        private SCore.Selenium _browser;

        public void Initialize(SCore.Selenium browser)
        {
            Initialize(browser, _url);
        }

        public void Initialize(SCore.Selenium browser, string url)
        {
            _browser = browser;

            _browser.Initialize();

            _browser.Navigation.OpenUrl(url);
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
            var element = browser.Element.FindElementById(_elementId);

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
            var element = browser.Element.FindElementById(_elementIdNotFound);

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
            var id = By.Id(_elementId);
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
            var id = By.Id(_elementIdNotFound);
            Initialize(browser);

            // Act
            var element = browser.Element.FindElement(id);

            // Assert
            Assert.True(element == null);
        }


        [Trait("Submit", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void Submit_InPage_LogInToSystem(SCore.Selenium browser)
        {
            // Arrange
            var button = By.Id("idSIButton9");
            var txtLogin = By.Name("loginfmt");
            var txtPasswd = By.Name("passwd");
            var valLogin = "luan_govinda777@hotmail.com";
            var valPass = "Hermeserenato1";
            string currentUrl;
            string resultUrl = @"http://account.microsoft.com";
            Initialize(browser, @"https://login.live.com/login.srf");

            // Act
            browser.Element.SendKeys(txtLogin, valLogin);
            browser.Element.SendKeys(txtPasswd, valPass);
            browser.Element.Click(button);
            currentUrl = browser.Navigation.GetCurrentUrl();

            // Assert
            Assert.True(resultUrl.Normalize() == currentUrl.NormalizeUrl());
        }

        [Trait("Click", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void Click_InPage_ClickInTheButton(SCore.Selenium browser)
        {
            // Arrange
            var button = By.ClassName(_button);
            var resultUrl = @"https://login.live.com/login.srf";
            string currentUrl;
            Initialize(browser, _url2);

            // Act
            browser.Element.Click(button);
            currentUrl = browser.Navigation.GetCurrentUrl();

            // Assert
            Assert.True(currentUrl.NormalizeUrl() == resultUrl.NormalizeUrl());
        }

        [Trait("SendKeys", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void SendKeys_InPage_WriteLogin(SCore.Selenium browser)
        {
            Initialize(browser, @"https://login.live.com/login.srf");

            // Arrange
            var txtLogin = By.Name("loginfmt");
            var valLogin = "luan_govinda777@hotmail.com";
            
            // Act
            browser.Element.SendKeys(txtLogin, valLogin);

            // Assert
            Assert.True(browser.Element.GetValue(txtLogin) == valLogin);
        }

        [Trait("GetAttribute", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void GetAttribute_InPage_GetTheValueOfTheLoginField(SCore.Selenium browser)
        {
            Initialize(browser, @"https://login.live.com/login.srf");

            // Arrange
            var txtLogin = By.Name("loginfmt");
            var valLogin = "luan_govinda777@hotmail.com";
            string attr;

            // Act
            browser.Element.SendKeys(txtLogin, valLogin);
            attr = browser.Element.GetAttribute(txtLogin, "value");

            // Assert
            Assert.True(attr == valLogin);
        }

        [Trait("GetValue", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void GetValue_InPage_GetTheValueOfTheLoginField(SCore.Selenium browser)
        {
            Initialize(browser, @"https://login.live.com/login.srf");

            // Arrange
            var txtLogin = By.Name("loginfmt");
            var valLogin = "luan_govinda777@hotmail.com";
            string attr;

            // Act
            browser.Element.SendKeys(txtLogin, valLogin);
            attr = browser.Element.GetValue(txtLogin);

            // Assert
            Assert.True(attr == valLogin);
        }

        [Trait("SelectDropDownByValue", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void SelectDropDownByValue_InDDL_SelectTheBRLValue(SCore.Selenium browser)
        {
            Initialize(browser, @"https://www.paypal.com/us/webapps/mpp/home");

            // Arrange
            var passo1 = By.Id("header-send");
            var dropDown = By.Id("currency_code");
            string value;

            // Act
            browser.Element.Click(passo1);
            browser.Element.SelectDropDownByValue(dropDown, "BRL");
            value = browser.Element.GetValue(dropDown);

            // Assert
            Assert.True(value == "BRL");            
        }
        
        [Trait("SelectDropDownByText", "Element")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void SelectDropDownByText_InDDL_SelectTheBRLValue(SCore.Selenium browser)
        {
            Initialize(browser, @"https://www.paypal.com/us/webapps/mpp/home");

            // Arrange
            var passo1 = By.Id("header-send");
            var dropDown = By.Id("currency_code");
            string value;

            // Act
            browser.Element.Click(passo1);
            browser.Element.SelectDropDownByText(dropDown, "BRL");
            value = browser.Element.GetValue(dropDown);

            // Assert
            Assert.True(value == "BRL");
        }
    }
}
