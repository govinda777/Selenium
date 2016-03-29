using System;
using OpenQA.Selenium;
using Selenium.Core.Interface;
using Selenium.Infra.Helper;
using Selenium.Infra.Helper.Interface;

namespace Selenium.Core
{
    public class Selenium : ISelenium
    {
        private IWebDriver _driver;
        private IScreenCapture _screenCapture;
        private ISafeExecution _safeExecution;
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
            _driver = SingletonWebDriver.GetInstance(_webDriverType, _driverServerDirectory).GetDriver();
            _screenCapture = new ScreenCapture(_pathEvidence);
            _safeExecution = new SafeExecution(_screenCapture);

            Element = new Element(_driver, _safeExecution);
            Navigation = new Navigation(_driver, _safeExecution);
        }

    }
}
