using System;
using Iteris.Selenium.Core.Selemiun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Iteris.Selenium.Test
{
    [TestClass]
    public class TestCase
    {
        Tools<ChromeDriver> Tools;
        public const string APPURL = @"http://pi:17000/_layouts/redecard/Login.aspx";

        [TestInitialize]
        public void TestInitialize()
        {
            Tools = new Tools<ChromeDriver>();
            Tools.Navigation.OpenUrl(APPURL);
        }

        [TestMethod]
        public void TestCase1()
        {
            var usuario = Tools.Element.FindElementById("ctl00_PlaceHolderMain_UserName");
            var pass = Tools.Element.FindElementById("ctl00_PlaceHolderMain_Password");

            Tools.Element.SendKeys(usuario, "administrator");
            Tools.Element.SendKeys(pass, "It3r1510");
            Tools.Element.Click(By.ClassName("botao-principal"));

        }


    }
}
