using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Facede.Selenium.TestAcceptance
{
    [Binding]
    public class LoginStepDefinition
    {
        [Given(@"Que possuo usuario e senha validos")]
        public void DadoQuePossuoUsuarioESenhaValidos()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"For me logar na aplicacao com os dados")]
        public void QuandoForMeLogarNaAplicacaoComOsDados(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Conseguirei me logar")]
        public void EntaoConseguireiMeLogar()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

