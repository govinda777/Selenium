using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;

namespace Facade.Selenium.Core
{
    /// <summary>
    /// Classe responsável por impedir que existam várias instancias de WebDriver, 
    /// o tipo T apenas pode ser uma classe que implementa IWebDriver
    /// </summary>
    /// <typeparam name="T">Classe que implementa IWebDriver</typeparam>
    public class SingletonWebDriver<T> where T : IWebDriver
    {
        private string _driverServerDirectory;
        private IWebDriver _driver;

        /// <summary>
        /// Atributo estatico onde terá a unica intancia do web driver
        /// </summary>
        private static SingletonWebDriver<T> _uniqueInstance;

        /// <summary>
        /// Construtor receberá qualquer classe que implemente IWebDriver conforme fala a assinatura da classe  
        /// </summary>
        public SingletonWebDriver(string driverServerDirectory) 
        {
            _driverServerDirectory = driverServerDirectory;
            _driver = GetWebDriver();
        }

        /// <summary>
        /// Retorna uma nova instancia de WebDriver de acordo com o tipo
        /// </summary>
        private IWebDriver GetWebDriver()
        {
            if (typeof(T) == typeof(FirefoxDriver))
            {
                return new FirefoxDriver();
            }
            
            return (T)Activator.CreateInstance(typeof(T) , new object[] { _driverServerDirectory });
        }

        /// <summary>
        /// Retorna o WebDriver 
        /// </summary>
        /// <returns></returns>
        public IWebDriver GetDriver()
        {
            return _driver;
        }

        /// <summary>
        /// Retorna a unica instancia de SingletonWebDriver caso ainda não tenha sido instanciado
        /// </summary>
        /// <param name="driverServerDirectory">Caminho que está o Webdriver</param>
        public static SingletonWebDriver<T> GetInstance(string driverServerDirectory)
        {            
            if (_uniqueInstance == null)
            {
                _uniqueInstance = new SingletonWebDriver<T>(driverServerDirectory);
            }

            return _uniqueInstance;
        }

    }
}
