using System;
using Facade.Selenium.Core.Interface;
using Facade.Selenium.Infra.Helper.Interface;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Facade.Selenium.Core
{
    /// <summary>
    /// Classe responsável pela manipulação dos elementos
    /// </summary>
    public class Element : IElement
    {
        private readonly IWebDriver _driver;
        private readonly ISafeExecution _safeExecution;

        public Element(IWebDriver driver, ISafeExecution safeExecution)
        {
            _driver = driver;
            _safeExecution = safeExecution;

            Initialize();
        }

        public void Initialize()
        {
            _safeExecution.Execute(() => {
                _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            });
        }

        /// <summary>
        /// Procura o elemento pelo ID
        /// </summary>
        /// <param name="elementId"></param>
        /// <returns></returns>
        public IWebElement FindElementById(string elementId)
        {            
            return _safeExecution.Execute<IWebElement>(() => _driver.FindElement(By.Id(elementId)));
        }

        /// <summary>
        /// Procura o elemento pelo nome
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        public IWebElement FindElementByName(string elementName)
        {
            return _safeExecution.Execute<IWebElement>(() => _driver.FindElement(By.Name(elementName)));
        }

        /// <summary>
        /// Procura o elemento pelo nome
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public IWebElement FindElementByClassName(string className)
        {
            return _safeExecution.Execute<IWebElement>(() => _driver.FindElement(By.ClassName(className)));
        }

        /// <summary>
        /// Procura o elemento de acordo com o parametro selector
        /// </summary>
        /// <param name="selector">Seletor</param>
        /// <returns></returns>
        public IWebElement FindElement(By selector)
        {
            return _safeExecution.Execute<IWebElement>(() => _driver.FindElement(selector));
        }

        /// <summary>
        /// Realiza um submit de acordo com o seletor, 
        /// Atenção o seletor que encontrar um elemento input type submit
        /// </summary>
        /// <param name="selector">Seletor</param>
        public void Submit(By selector)
        {
            var evidenceName = "Submit";

            _safeExecution.ExecuteWithEvidence(evidenceName, () =>
            {
                _driver.SwitchTo().ActiveElement().Equals(_driver.FindElement(selector));

                _driver.FindElement(selector).Submit();
            });
        }

        /// <summary>
        /// Dispata o evento clique de acordo com o parametro seletor
        /// </summary>
        /// <param name="selector">Seletor</param>
        public void Click(By selector)
        {
            string evidenceName = "Click";

            _safeExecution.ExecuteWithEvidence(evidenceName, () =>
            {
                _driver.SwitchTo().ActiveElement().Equals(_driver.FindElement(selector));

                _driver.FindElement(selector).Click();
            });
        }

        /// <summary>
        /// Escreve no elemento selecionado
        /// </summary>
        /// <param name="element">Elemento</param>
        /// <param name="value">Valor que será preenchido</param>
        public void SendKeys(IWebElement element, string value)
        {
            string evidenceName = $"Escrevendo '{value}' no campo '{element.TagName}' ";

            _safeExecution.ExecuteWithEvidence(evidenceName, () =>
            {
                element.Clear();
                element.SendKeys(value);
            });
        }

        /// <summary>
        /// Retorna o valor do atributo informado
        /// </summary>
        /// <param name="elementId">Id do elemento</param>
        /// <param name="attributeName">Nome do atributo que deseja recuperar o valor dele</param>
        /// <returns></returns>
        public string GetAttribute(string elementId, string attributeName)
        {
            return _safeExecution.Execute(() => FindElementById(elementId).GetAttribute(attributeName));
        }

        /// <summary>
        /// Pega o valor do elemento
        /// </summary>
        /// <param name="elementId">Id do elemento</param>
        /// <returns></returns>
        public string GetValue(string elementId)
        {
            return _safeExecution.Execute(() => FindElementById(elementId).GetAttribute("value"));
        }

        /// <summary>
        /// Selecioa um valor de um combo
        /// </summary>
        /// <param name="element">Elemento</param>
        /// <param name="value">Valor que deverá ser selecionado</param>
        public void SelectDropDownByValue(IWebElement element, string value)
        {
            _safeExecution.ExecuteWithEvidence(() =>
            {
                var selectElement = new SelectElement(element);

                //select by value
                selectElement.SelectByValue(value);
            });
        }

        /// <summary>
        /// Selecioa um valor de um combo pelo texto
        /// </summary>
        /// <param name="element">Elemento</param>
        /// <param name="text">Texto que deverá ser selecionado</param>
        public void SelectDropDownByText(IWebElement element, string text)
        {
            _safeExecution.ExecuteWithEvidence(() =>
            {
                var selectElement = new SelectElement(element);
                
                selectElement.SelectByText(text);
            });
        }

    }
}
