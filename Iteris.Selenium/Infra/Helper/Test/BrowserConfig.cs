using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Selenium.Infra.ReadConfig;
using System;
using System.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;

namespace Selenium.Infra.Helper.Test
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
        
        public BrowsersElement GetBrowsersElement(Type browser)
        {
            return (from BrowsersElement be in _browsersElements
                    where be.WebDriverType == browser.Name
                    select be).FirstOrDefault();
        }

        public Core.Selenium GetBrowser(Type browser)
        {
            var browsersElement = GetBrowsersElement(browser);
            
            if (browser == typeof(ChromeDriver))
            {
                return new Core.Selenium(typeof(ChromeDriver), browsersElement.DriverServerDirectory, browsersElement.PathEvidence);
            }

            if (browser == typeof(FirefoxDriver))
            {
                return  new Core.Selenium(typeof(FirefoxDriver), browsersElement.DriverServerDirectory, browsersElement.PathEvidence);
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