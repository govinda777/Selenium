using Facade.Selenium.Infra.Helper;
using Facade.Selenium.Infra.Helper.Browser;
using System;
using System.Linq;
using Xunit;
using SCore = Facade.Selenium.Core;

namespace Selenium.Test.Core
{
    public class NavigationTest
    {
        private readonly string _url = @"http://iteris.com.br/v2/";
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

        [Trait("OpenUrl", "Navigation")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void OpenUrl_InPage_OpenTheNewPage(SCore.Selenium browser)
        {
            Initialize(browser);

            // Arrange
            string currentUrl;

            // Act
            browser.Navigation.OpenUrl(_url);
            currentUrl = browser.Navigation.GetCurrentUrl();

            // Assert
            Assert.True(currentUrl.NormalizeUrl() == _url.NormalizeUrl());
        }

        [Trait("GetCurrentUrl", "Navigation")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void GetCurrentUrl_InPage_CheckIfTheCurrentURLIsThatItWasOpen(SCore.Selenium browser)
        {
            Initialize(browser);

            // Arrange
            string currentUrl;

            // Act
            browser.Navigation.OpenUrl(_url);
            currentUrl = browser.Navigation.GetCurrentUrl();

            // Assert
            Assert.True(currentUrl.NormalizeUrl() == _url.NormalizeUrl());
        }

        [Trait("NavigateBack", "Navigation")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void NavigateBack(SCore.Selenium browser)
        {
            Initialize(browser);

            // Arrange
            string currentUrl;
            var secondUrl = "google.com.br";

            // Act
            browser.Navigation.OpenUrl(_url);
            browser.Navigation.OpenUrl(secondUrl);
            browser.Navigation.NavigateBack();
            currentUrl = browser.Navigation.GetCurrentUrl();

            // Assert
            Assert.True(currentUrl.NormalizeUrl() == _url.NormalizeUrl());
        }


        [Trait("CloseWebBrowser", "Navigation")]
        [Theory]
        [ClassData(typeof(BrowserConfig))]
        public void CloseWebBrowser(SCore.Selenium browser)
        {
            Initialize(browser);

            // Arrange
            string currentUrl;

            // Act
            browser.Navigation.OpenUrl(_url);
            browser.Navigation.CloseWebBrowser();
            currentUrl = browser.Navigation.GetCurrentUrl();

            // Assert
            Assert.True(currentUrl.NormalizeUrl() == "about:blank");
        }
    }
}
