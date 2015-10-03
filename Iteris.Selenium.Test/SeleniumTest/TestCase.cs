using System;
using Iteris.Selenium.Core.Selemiun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Selenium.Test.SeleniumTest
{
    [TestClass]
    public class TestCase
    {
        Element element;
        Navigation navigation;
        public const string APPURL = @"http://pi:17000/_layouts/redecard/Login.aspx";

        [TestInitialize]
        public void TestInitialize()
        {
            element = new Element();
            navigation = new Navigation();

            navigation.OpenUrl(APPURL);
        }

        [TestMethod]
        public void TestCase1()
        {
            var usuario = element.FindElementById("ctl00_PlaceHolderMain_UserName");
            var pass = element.FindElementById("ctl00_PlaceHolderMain_Password");

            element.SendKeys(usuario,"administrator");
            element.SendKeys(pass,"It3r1510");
            element.Click(By.ClassName("botao-principal"));

        }


    }
}
