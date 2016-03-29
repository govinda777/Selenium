using System;
using OpenQA.Selenium;
using Selenium.Infra.Helper.Interface;
using INavigation = Selenium.Core.Interface.INavigation;

namespace Selenium.Core
{
    /// <summary>
    /// Classe responsavel pelos métodos de navegação 
    /// </summary>
    public class Navigation : INavigation
    {
        private readonly IWebDriver _driver;
        private readonly ISafeExecution _safeExecution;

        public Navigation(IWebDriver driver, ISafeExecution safeExecution)
        {
            _driver = driver;
            _safeExecution = safeExecution;

            Initialize();
        }
        
        public void Initialize()
        {
            _safeExecution.Execute(() =>
            {
                _driver.Manage().Window.Maximize();
            });
        }
        
        /// <summary>
        /// Fecha o Browser
        /// </summary>
        public void CloseWebBrowser()
        {
            _safeExecution.Execute(() =>
            {
                _driver.Navigate().GoToUrl("about:blank");
            });
        }

        /// <summary>
        /// Abre uma URL
        /// </summary>
        /// <param name="url"></param>
        public void OpenUrl(string url)
        {
            _safeExecution.ExecuteWithEvidence("Abrindo url", () =>
            {
                _driver.Navigate().GoToUrl(url);
            });
        }

        /// <summary>
        /// Pega a corrente URL
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUrl()
        {
            return _safeExecution.Execute<string>(() =>
            {
                return _driver.Url;
            });
        }

        /// <summary>
        /// Simula o botão voltar
        /// </summary>
        public void NavigateBack()
        {
            _safeExecution.ExecuteWithEvidence("Voltando página", () =>
            {
                _driver.Navigate().Back();
            });
        }

        /// <summary>
        /// Fecha o browser
        /// </summary>
        public void Dispose()
        {
            CloseWebBrowser();
        }
    }
}
