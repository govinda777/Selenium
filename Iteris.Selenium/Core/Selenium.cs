using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Facade.Selenium.Core
{
    public class Selenium : ISelenium
    {
        private readonly Type _webDriverType;
        private readonly string _driverServerDirectory;
        private readonly string _pathEvidence;

        public Element Element { get; set; }

        public Navigation Navigation { get; set; }

        public Selenium(Type webDriverType, string driverServerDirectory, string pathEvidence)
        {
            _webDriverType = webDriverType;
            _driverServerDirectory = driverServerDirectory;
            _pathEvidence = pathEvidence;
        }

        public Selenium(Type webDriverType, string driverServerDirectory)
        {
            _webDriverType = webDriverType;
            _driverServerDirectory = driverServerDirectory;
        }

        public Selenium(Type webDriverType)
        {
            _webDriverType = webDriverType;
        }

        public void Initialize()
        {


            Element = new Element(_webDriverType, _driverServerDirectory, _pathEvidence);
            Navigation = new Navigation(_webDriverType, _driverServerDirectory, _pathEvidence);
        }

    }
}
