using System;
using OpenQA.Selenium;

namespace Facade.Selenium.Core
{
    /// <summary>
    /// Classe responsavel pelos métodos de navegação 
    /// </summary>
    /// <typeparam name="T">Classe que implementa IWebDriver</typeparam>
    public class Navigation<T> : Base<T>, IDisposable where T : IWebDriver
    {
        /// <summary>
        /// Construtor 
        /// </summary>
        public Navigation(string driverServerDirectory)
            : base(driverServerDirectory)
        {
            Execute(() =>
            {
                driver.Manage().Window.Maximize();
            });
        }

        /// <summary>
        /// Fecha o Browser
        /// </summary>
        public void CloseWebBrowser()
        {
            Execute(() =>
            {
                driver.Navigate().GoToUrl("about:blank");
            });
        }

        /// <summary>
        /// Abre uma URL
        /// </summary>
        /// <param name="url"></param>
        public void OpenUrl(string url)
        {
            ExecuteWithEvidence("Abrindo url", () =>
            {
                driver.Navigate().GoToUrl(url);
            });
        }

        /// <summary>
        /// Pega a corrente URL
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUrl()
        {
            return Execute<string>(() =>
            {
                return driver.Url;
            });
        }

        /// <summary>
        /// Simula o botão voltar
        /// </summary>
        public void NavigateBack()
        {
            ExecuteWithEvidence("Voltando página", () =>
            {
                driver.Navigate().Back();
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
