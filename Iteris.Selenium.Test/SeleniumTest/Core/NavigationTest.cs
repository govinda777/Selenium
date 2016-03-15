using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facade.Selenium.Core.Helper;
using Facade.Selenium.Core.Selemiun;
using OpenQA.Selenium.Chrome;

namespace Facade.Selenium.Test.SeleniumTest.Core
{
    [TestClass]
    public class NavigationTest
    {
        Navigation<ChromeDriver> navigation;

        [TestInitialize]
        public void TestInitialize()
        {
            navigation = new Navigation<ChromeDriver>();
        }

        [TestMethod]
        public void OpenUrlTest()
        {
            navigation.OpenUrl("https://www.google.com.br/?gws_rd=ssl");

            string currentUrl = navigation.GetCurrentUrl();

            Assert.IsTrue(!string.IsNullOrEmpty(currentUrl) && currentUrl.Contains("https://www.google.com.br/?gws_rd=ssl"));
        }

        [TestMethod]
        public void GetCurrentUrlTest()
        {
            navigation.OpenUrl("https://www.google.com.br/?gws_rd=ssl");

            string currentUrl = navigation.GetCurrentUrl();

            Assert.IsTrue(!string.IsNullOrEmpty(currentUrl) && currentUrl == "https://www.google.com.br/?gws_rd=ssl");
        }

        [TestMethod]
        public void NavigateBackTest()
        {
            navigation.OpenUrl("https://www.google.com.br/?gws_rd=ssl");

            navigation.OpenUrl("http://uol.com.br");

            navigation.NavigateBack();

            string currentUrl = navigation.GetCurrentUrl();

            Assert.IsTrue(!string.IsNullOrEmpty(currentUrl) && currentUrl == "https://www.google.com.br/?gws_rd=ssl");
        }


        [TestCleanup]
        public void TestCleanup()
        {
            navigation.Dispose();
            navigation = null;
        }
    }
}
