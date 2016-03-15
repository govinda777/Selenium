using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Configuration;
using Facade.Selenium.Infra;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Facade.Selenium.Infra.Helper;

namespace Facade.Selenium.Core
{
    /// <summary>
    /// Classe base para Selemiun
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Base<T> where T : IWebDriver
    {
        public readonly IWebDriver driver;
        private string _pathEvidence = @"C:\Evidencias\" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        private ScreenCapture screenCapture;

        /// <summary>
        /// Construtor
        /// Pega uma instancia de IWebDriver de acordo com o driver requisitado 
        /// </summary>
        public Base() 
        {
            driver = SingletonWebDriver<T>.GetInstance().GetDriver();
            screenCapture = new ScreenCapture();
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
                LogarErro(ex);
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
                LogarErro(ex);
            }

            return (T)Activator.CreateInstance(typeof(T));;
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
            CaptureScreen(evidenceName);   
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

            CaptureScreen(evidenceName);

            return result;
        }

        #endregion

        public void LogarErro(Exception ex)
        {

        }

        /// <summary>
        /// Faz um print da tela e o salva sem um diretório previamente definido
        /// </summary>
        public void CaptureScreen()
        {
            CaptureScreen(string.Empty);
        }

        /// <summary>
        /// Faz um print da tela e o salva sem um diretório previamente definido
        /// </summary>
        /// <param name="evidenceName">Nome do arquivo que será salvo como evidencia</param>
        public void CaptureScreen(string evidenceName)
        {
            if (!Directory.Exists(_pathEvidence))
            {
                Directory.CreateDirectory(_pathEvidence);
            }

            string file  = string.Concat(DateTime.Now.Hour , "-" , 
                                         DateTime.Now.Minute , "-" , 
                                         DateTime.Now.Second,
                                         " ",
                                         string.IsNullOrEmpty(evidenceName) ? string.Empty : evidenceName,
                                        ".gif");

            try
            {
                screenCapture.CaptureScreen()
                             .Save(Path.Combine(_pathEvidence, file), ImageFormat.Gif);
            }
            catch (Exception ex)
            {
                LogarErro(ex);
            }
            
        }
    }

}
