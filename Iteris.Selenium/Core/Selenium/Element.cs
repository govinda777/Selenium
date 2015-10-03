using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Iteris.Selenium.Core.Selemiun
{
    public class Element : Base
    {
        public Element()
            : base()
        {
            Execute(() => {
                driverIe.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            });
        }

        public IWebElement FindElementById(string elementId)
        {            
            return Execute<IWebElement>(() =>
            {
                return driverIe.FindElement(By.Id(elementId));
            });
        }

        public IWebElement FindElementByName(string elementName)
        {
            return Execute<IWebElement>(() =>
            {
                return driverIe.FindElement(By.Name(elementName));
            });
        }

        public IWebElement FindElementByClassName(string className)
        {
            return Execute<IWebElement>(() =>
            {
                return driverIe.FindElement(By.ClassName(className));
            });
        }

        public IWebElement FindElement(By selector)
        {
            return Execute<IWebElement>(() =>
            {
                return driverIe.FindElement(selector);
            });
        }

        public void Submit(By selector)
        {
            string evidenceName = "Submit";

            ExecuteWithEvidence(evidenceName, () =>
            {
                driverIe.SwitchTo().ActiveElement().Equals(driverIe.FindElement(selector));

                driverIe.FindElement(selector).Submit();
            });
        }

        public void Click(By selector)
        {
            string evidenceName = "Click";

            ExecuteWithEvidence(evidenceName, () =>
            {
                driverIe.SwitchTo().ActiveElement().Equals(driverIe.FindElement(selector));

                driverIe.FindElement(selector).Click();
            });
        }

        public void SendKeys(IWebElement element, string value)
        {
            string evidenceName = string.Format("Escrevendo '{0}' no campo '{1}' ", value, element.TagName);

            ExecuteWithEvidence(evidenceName, () =>
            {
                element.Clear();
                element.SendKeys(value);
            });
        }

        public string GetAttribute(string idSelector, string attributeName)
        {
            return Execute(() =>
            {
                return FindElementById(idSelector).GetAttribute(attributeName);
            });
        }

        public string GetValue(string idSelector)
        {
            return Execute(() =>
            {
                return FindElementById(idSelector).GetAttribute("value");
            });
        }

        public void SelectDropDownByValue(IWebElement element, string value)
        {
            ExecuteWithEvidence(() =>
            {
                var selectElement = new SelectElement(element);

                //select by value
                selectElement.SelectByValue(value);
            });
        }

        public void SelectDropDownByText(IWebElement element, string text)
        {
            ExecuteWithEvidence(() =>
            {
                var selectElement = new SelectElement(element);

                // select by text
                selectElement.SelectByText(text);
            });
        }

    }
}
