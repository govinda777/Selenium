using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SCore = Facade.Selenium.Core;

namespace Facede.Selenium.TestAcceptance
{
    [Binding]
    public class LoginStepDefinition
    {
        private readonly string _url = @"https://www.microsoft.com/pt-br/account";
        private SCore.Selenium _browser;
        
        public LoginStepDefinition()
        {
            Initialize(_url);
        }

        public void Initialize(string url)
        {/*
            Browser.Current

            _browser = browser;

            _browser.Initialize();

            _browser.Navigation.OpenUrl(url);*/
        }

        [Given(@"Que possuo usuario e senha validos")]
        public void DadoQuePossuoUsuarioESenhaValidos()
        {
   
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

