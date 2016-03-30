using OpenQA.Selenium;

namespace Facade.Selenium.Core.Interface
{
    public interface IElement
    {
        void Initialize();
        IWebElement FindElementById(string elementId);
        IWebElement FindElementByName(string elementName);
        IWebElement FindElementByClassName(string className);
        IWebElement FindElement(By selector);
        void Submit(By selector);
        void Click(By selector);
        void SendKeys(IWebElement element, string value);
        string GetAttribute(string elementId, string attributeName);
        string GetValue(string elementId);
        void SelectDropDownByValue(IWebElement element, string value);
        void SelectDropDownByText(IWebElement element, string text);
    }
}