using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace ValidadorSenha.Api.Testes.Api
{
    [SetUpFixture]
    public class ConfiguracaoBase
    {
        [OneTimeSetUp]
        public void InicializarAmbienteDeTestes() 
        {
            var hostBuilder = new WebApplicationFactory<Startup>();
            VariaveisGlobais.HttpClient = hostBuilder.CreateDefaultClient();
        }
    }
}
