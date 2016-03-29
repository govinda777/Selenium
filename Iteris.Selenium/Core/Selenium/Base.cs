using System;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using System.IO;
using Facade.Selenium.Infra.Helper;
using OpenQA.Selenium.Remote;

namespace Facade.Selenium.Core
{
    /// <summary>
    /// Classe base para Selemiun
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Base<T> where T : IWebDriver
    {
        public readonly IWebDriver driver;
        private string _driverServerDirectory;
        private string _pathEvidence;

        private ScreenCapture screenCapture;
        
        public Base()
        {
            driver = SingletonWebDriver<T>.GetInstance(_driverServerDirectory).GetDriver();
            screenCapture = new ScreenCapture(_pathEvidence);
        }
        
        public Base(string driverServerDirectory) : this()
        {
            _driverServerDirectory = driverServerDirectory;
        }
        
        public Base(string driverServerDirectory, string pathEvidence) : this(driverServerDirectory)
        {
            _pathEvidence = pathEvidence;
        }

        #region Execute

        /// <summary>
        /// Executa a ação e realiza um try cache caso ocorra algum erro.
        /// </summary>
        /// <param name="action">Código que será executado</param>
        public void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        /// <summary>
        /// Executa a ação e realiza um try cache caso ocorra algum erro.
        /// </summary>
        /// <typeparam name="T">Tipo de dado que será retornado</typeparam>
        /// <param name="action">Código que será executado com retorno especificado em T</param>
        /// <returns>Retornará o que foi definido em T</returns>
        public T Execute<T>(Func<T> action)
        {
            try
            {
                T result = action.Invoke();

                return result;
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

            return (T)Activator.CreateInstance(typeof(T));
        }

        #endregion

        #region ExecuteWithEvidence

        /// <summary>
        /// Executa a ação solicitada e gera um print evidenciando o resultado
        /// </summary>
        /// <param name="action">Ação que será executada</param>
        public void ExecuteWithEvidence(Action action)
        {
            ExecuteWithEvidence(string.Empty, action);
        }

        /// <summary>
        /// Executa a ação solicitada e gera um print evidenciando o resultado
        /// </summary>
        /// <param name="evidenceName">Nome da evidencia (nome do arquivo de print)</param>
        /// <param name="action">Ação que será executada</param>
        public void ExecuteWithEvidence(string evidenceName, Action action)
        {
            Execute(action);
            screenCapture.CaptureScreen(evidenceName);   
        }

        /// <summary>
        /// Executa a ação solicitada e gera um print evidenciando o resultado
        /// </summary>
        /// <typeparam name="T">Tipo de dado que será retornado</typeparam>
        /// <param name="action">Ação que será executada</param>
        /// <returns>Retornará o que foi definido em T</returns>
        public T ExecuteWithEvidence<T>(Func<T> action)
        {
            return ExecuteWithEvidence<T>(string.Empty, action);
        }

        /// <summary>
        /// Executa a ação solicitada e após printa uma evidencia
        /// </summary>
        /// <typeparam name="T">Tipo de dado que será retornado</typeparam>
        /// <param name="evidenceName">Nome da evidencia</param>
        /// <param name="action">Ação que será executada</param>
        /// <returns>Retornará o que foi definido em T</returns>
        public T ExecuteWithEvidence<T>(string evidenceName, Func<T> action)
        {
            T result = Execute<T>(action);

            new ScreenCapture().CaptureScreen(evidenceName);

            return result;
        }

        #endregion

        public void LogError(Exception ex)
        {

        }

    }

}
