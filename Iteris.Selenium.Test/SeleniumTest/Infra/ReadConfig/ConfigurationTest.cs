using System.Configuration;
using Xunit;
using Selenium.Infra.ReadConfig;

namespace Selenium.Test.SeleniumTest.Infra.ReadConfig
{
    public class ConfigurationTest
    {
        [Trait("Category", "CI")]
        [Fact]
        public void Configuration_Validar_Configuracoes()
        {
            var config = ConfigurationManager.GetSection(BrowserSection.SectionName) as BrowserSection;

            Assert.True(config != null);
        }

    }
}