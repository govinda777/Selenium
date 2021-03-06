﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Facade.Selenium.Infra.ReadConfig;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace Facade.Selenium.Infra.Helper.Browser
{
    public class BrowserConfig : IEnumerable<object[]>
    {
        private BrowsersElementCollection _browsersElements
        {
            get
            {
                var browserSection = ConfigurationManager.GetSection(BrowserSection.SectionName) as BrowserSection;

                if (browserSection?.BrowsersElements != null)
                {
                    return browserSection.BrowsersElements;
                }

                throw new ConfigurationErrorsException();
            }
        }

        public string GetBrowsersElement(string browser)
        {
            return Path.Combine(System.Environment.CurrentDirectory, "Webdriver", browser);
        }

        public BrowsersElement GetBrowsersElement(Type browser)
        {
            return (from BrowsersElement be in _browsersElements
                    where be.WebDriverType == browser.Name
                    select be).FirstOrDefault();
        }

        public Core.Selenium GetBrowser(Type browser)
        {
            var driverServerDirectory = GetBrowsersElement(browser.Name);
            
            if (browser == typeof(ChromeDriver))
            {
                return new Facade.Selenium.Core.Selenium(typeof(ChromeDriver), driverServerDirectory);
            }
            
            if (browser == typeof(FirefoxDriver))
            {
                return  new Facade.Selenium.Core.Selenium(typeof(FirefoxDriver), driverServerDirectory);
            }
            
            return null;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            if (GetBrowsersElement(typeof(ChromeDriver)) != null)
            {
                yield return new object[] { GetBrowser(typeof(ChromeDriver)) };
            }

            if (GetBrowsersElement(typeof (FirefoxDriver)) != null)
            {
                yield return new object[] { GetBrowser(typeof(FirefoxDriver)) };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}