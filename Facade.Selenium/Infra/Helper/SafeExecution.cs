using System;
using Facade.Selenium.Infra.Helper.Interface;
using System.Threading;

namespace Facade.Selenium.Infra.Helper
{
    /// <summary>
    /// Classe base para Selemiun
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SafeExecution : ISafeExecution
    {
        private readonly IScreenCapture _screenCapture;
        
        public SafeExecution(IScreenCapture screenCapture)
        {
            _screenCapture = screenCapture;
        }

        #region Execute

        /// <summary>
        /// Executa a ação e realiza um try catch caso ocorra algum erro.
        /// </summary>
        /// <param name="action">Código que será executado</param>
        public void Execute(Action action)
        {
            try
            {
                action();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                
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
                
            }

            return default(T);
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
            _screenCapture.CaptureScreen(evidenceName);   
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

            _screenCapture.CaptureScreen(evidenceName);

            return result;
        }

        #endregion
        
    }

}
