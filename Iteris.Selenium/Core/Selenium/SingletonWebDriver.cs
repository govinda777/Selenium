using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace Iteris.Selenium.Core.Selemiun
{
    /// <summary>
    /// Classe responsável por impedir que existam várias instancias de WebDriver, 
    /// o tipo T apenas pode ser uma classe que implementa IWebDriver
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonWebDriver<T> where T : IWebDriver
    {
        /// <summary>
        /// Pega o caminho do executável para criar o web driver do IE 
        /// </summary>
        private string IEServerselenium = ConfigurationManager.AppSettings["IEDriverServer"].ToString();
        private IWebDriver _driver;

        /// <summary>
        /// Atributo estatico onde terá a unica intancia do web driver
        /// </summary>
        private static SingletonWebDriver<T> _uniqueInstance;

        /// <summary>
        /// Construtor receberá qualquer classe que implemente IWebDriver conforme fala a assinatura da classe  
        /// </summary>
        /// <param name="type">Qual quer classe que implemente a interface IWebDriver</param>
        public SingletonWebDriver() 
        {
            _driver = GetWebDriver();
        }

        /// <summary>
        /// Retorna uma nova instancia de WebDriver de acordo com o tipo
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private IWebDriver GetWebDriver()
        {
            if(typeof(T) == typeof(InternetExplorerDriver))
            {
                return new InternetExplorerDriver(IEServerselenium);
            }
            else if (typeof(T) == typeof(FirefoxDriver))
            {
                return new FirefoxDriver();
            }
            else if (typeof(T) == typeof(OperaDriver))
            {
                return new OperaDriver();
            }

            return null;
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
        /// <param name="type"></param>
        /// <returns></returns>
        public static SingletonWebDriver<T> GetInstance()
        {            
            if (_uniqueInstance == null)
            {
                _uniqueInstance = new SingletonWebDriver<T>();
            }

            return _uniqueInstance;
        }

    }
}
