using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Configuration;
using Iteris.Selenium.Core.Helper;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Iteris.Selenium.Core.Selemiun
{
    public class Base<T> where T : IWebDriver
    {
        public readonly IWebDriver driver;
        private string _pathEvidence = @"C:\Evidencias\" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        private ScreenCapture screenCapture;

        public Base() 
        {
            driver = SingletonWebDriver<T>.GetInstance().GetDriver();
            screenCapture = new ScreenCapture();
        }
        
        #region Execute

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

        public void ExecuteWithEvidence(Action action)
        {
            ExecuteWithEvidence(string.Empty, action);
        }

        public void ExecuteWithEvidence(string evidenceName, Action action)
        {
            Execute(action);
            CaptureScreen(evidenceName);   
        }

        public T ExecuteWithEvidence<T>(Func<T> action)
        {
            return ExecuteWithEvidence<T>(string.Empty, action);
        }

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

        public void CaptureScreen()
        {
            CaptureScreen(string.Empty);
        }

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
