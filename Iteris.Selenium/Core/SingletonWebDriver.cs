using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Facade.Selenium.Core
{
    /// <summary>
    /// Classe responsável por impedir que existam várias instancias de WebDriver, 
    /// o tipo T apenas pode ser uma classe que implementa IWebDriver
    /// </summary>
    public class SingletonWebDriver
    {
        private string _driverServerDirectory;
        private Type _webDriverType;
        private IWebDriver _driver;

        /// <summary>
        /// Atributo estatico onde terá a unica intancia do web driver
        /// </summary>
        private static SingletonWebDriver _uniqueInstance;

        /// <summary>
        /// Construtor receberá qualquer classe que implemente IWebDriver conforme fala a assinatura da classe  
        /// </summary>
        public SingletonWebDriver(Type webDriverType,  string driverServerDirectory) 
        {
            _webDriverType = webDriverType;
            _driverServerDirectory = driverServerDirectory;
            _driver = GetWebDriver(_webDriverType);
        }

        /// <summary>
        /// Retorna uma nova instancia de WebDriver de acordo com o tipo
        /// </summary>
        private IWebDriver GetWebDriver(Type webDriverType)
        {
            if (webDriverType == typeof(FirefoxDriver))
            {
                return new FirefoxDriver(new FirefoxBinary(_driverServerDirectory),
                                         new FirefoxProfile());
            }

            if (webDriverType == typeof(ChromeDriver))
            {
                return new ChromeDriver(_driverServerDirectory);
            }
            
            return null;
        }

        /// <summary>
        /// Retorna o WebDriver 
        /// </summary>
        public IWebDriver GetDriver()
        {
            return _driver;
        }

        /// <summary>
        /// Retorna a unica instancia de SingletonWebDriver caso ainda não tenha sido instanciado
        /// </summary>
        public static SingletonWebDriver GetInstance(Type webDriverType, string driverServerDirectory)
        {    
            if (_uniqueInstance == null || webDriverType != _uniqueInstance._webDriverType)
            {
                Dispose();

                if(_uniqueInstance != null)
                {
                    _uniqueInstance._webDriverType = webDriverType;
                }

                _uniqueInstance = new SingletonWebDriver(webDriverType, driverServerDirectory);
            }

            return _uniqueInstance;
        }

        private static void Dispose()
        {
            if(_uniqueInstance != null && _uniqueInstance._driver != null)
            {
                _uniqueInstance._driver.Quit();
            }            
        }

    }
}
