using System;

namespace Facade.Selenium.Core
{
    /// <summary>
    /// Classe responsavel pelos métodos de navegação 
    /// </summary>
    /// <typeparam name="T">Classe que implementa IWebDriver</typeparam>
    public class Navigation : Base
    {
        public Navigation(Type webDriverType, string driverServerDirectory, string pathEvidence)
            : base(webDriverType, driverServerDirectory, pathEvidence)
        {
            Initialize();
        }

        public Navigation(Type webDriverType, string driverServerDirectory)
            : base(webDriverType, driverServerDirectory)
        {
            Initialize();
        }

        public Navigation(Type webDriverType)
            : base(webDriverType)
        {
            Initialize();
        }

        public void Initialize()
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
