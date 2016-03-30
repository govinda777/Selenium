using System.Configuration;

namespace Facade.Selenium.Infra.ReadConfig
{
    public class BrowserSection : ConfigurationSection
    {
        /// <summary>
        /// The name of this section in the app.config.
        /// </summary>
        public const string SectionName = "FacadeSelenium";

        private const string BrowsersElementCollection = "BrowsersElementCollection";

        [ConfigurationProperty(BrowsersElementCollection)]
        [ConfigurationCollection(typeof(BrowsersElementCollection), AddItemName = "add")]
        public BrowsersElementCollection BrowsersElements { get { return (BrowsersElementCollection)base[BrowsersElementCollection]; } }
    }
}