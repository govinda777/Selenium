using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facade.Selenium.Core.Helper;
using Facade.Selenium.Core.Selemiun;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Facade.Selenium.Test.SeleniumTest.Core
{
    [TestClass]
    public class ElementTest 
    {
        Element<ChromeDriver> element;
        Navigation<ChromeDriver> navigation;

        const string ID_ELEMENT = "usuario";        
        const string NAME_ELEMENT = "user";
        const string CLASS_ELEMENT = "cor9";
        const string CLASS_ELEMENT_BTN = "buttonSubmit";

        [TestInitialize]
        public void TestInitialize()
        {
            element = new Element<ChromeDriver>();
            navigation = new Navigation<ChromeDriver>();

            navigation.OpenUrl("http://www.uol.com.br/");
        }

        [TestMethod]
        public void FindElementByIdTest()
        {
            var elm = element.FindElementById(ID_ELEMENT);

            Assert.IsTrue(elm != null);
        }

        [TestMethod]
        public void FindElementByNameTest()
        {
            var elm = element.FindElementByName(NAME_ELEMENT);

            Assert.IsTrue(elm != null);
        }

        [TestMethod]
        public void FindElementByClassNameTest()
        {
            var elm = element.FindElementByClassName(CLASS_ELEMENT);

            Assert.IsTrue(elm != null);
        }

        [TestMethod]
        public void FindElement()
        {
            var elm = element.FindElement(By.Name(NAME_ELEMENT));

            Assert.IsTrue(elm != null);
        }

        [TestMethod]
        public void SendKeysTest()
        {
            var elm = element.FindElementById(ID_ELEMENT);

            element.SendKeys(elm, "Selenium");

            var value = element.GetAttribute(ID_ELEMENT, "value");

            Assert.IsTrue(value == "Selenium");
        }
        
        [TestMethod]
        public void GetAttributeTest()
        {
            var elm = element.FindElementById(ID_ELEMENT);

            element.SendKeys(elm, "Selenium");

            var value = element.GetAttribute(ID_ELEMENT, "value");

            Assert.IsTrue(value == "Selenium");
        }

        [TestMethod]
        public void GetValueTest()
        {
            var elm = element.FindElementById(ID_ELEMENT);

            element.SendKeys(elm, "Selenium");

            var value = element.GetValue(ID_ELEMENT);

            Assert.IsTrue(value == "Selenium");
        }

        [TestMethod]
        public void SubmitTest()
        {
            element.Submit(By.ClassName(CLASS_ELEMENT_BTN));

            var url = navigation.GetCurrentUrl();

            Assert.IsTrue(url == "https://acesso.uol.com.br/login.html?skin=webmail");
        }

        [TestMethod]
        public void ClickTest()
        {
            element.Click(By.ClassName(CLASS_ELEMENT_BTN));

            var url = navigation.GetCurrentUrl();

            Assert.IsTrue(url == "https://acesso.uol.com.br/login.html?skin=webmail");
        }

        [TestMethod]
        public void SelectDropDownByValueTest()
        {            

        }

        [TestMethod]
        public void SelectDropDownByTextTest()
        {            
        }


        [TestCleanup]
        public void TestCleanup()
        {
            navigation.Dispose();
            navigation = null;
            element = null;
        }
    }
}
