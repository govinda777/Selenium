using System.Configuration;

namespace Facade.Selenium.Infra.ReadConfig
{
    public class BrowsersElement : ConfigurationElement
    {
        [ConfigurationProperty("driverServerDirectory", IsRequired = false)]
        public string DriverServerDirectory
        {
            get { return (string)this["driverServerDirectory"]; }
            set { this["driverServerDirectory"] = value; }
        }

        [ConfigurationProperty("pathEvidence", IsRequired = false)]
        public string PathEvidence
        {
            get { return (string)this["pathEvidence"]; }
            set { this["pathEvidence"] = value; }
        }

        [ConfigurationProperty("webDriverType", IsRequired = true, IsKey = true)]
        public string WebDriverType
        {
            get { return (string)this["webDriverType"]; }
            set { this["webDriverType"] = value; }
        }
    }
}