using System.Configuration;

namespace Facade.Selenium.Infra.ReadConfig
{
    public class BrowsersElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new BrowsersElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((BrowsersElement)element).WebDriverType;
        }
    }
}
