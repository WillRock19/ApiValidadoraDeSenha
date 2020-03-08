using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ValidadorSenha.Api.Testes.Api.Controllers
{
    class WeatherForecastControllerTestes
    {
        private const string EndpointUrl = "/v1.0/WeatherForecast";
        private HttpClient _client;

        [SetUp]
        public void Inicializar()
            => _client = VariaveisGlobais.HttpClient;

        [Test]
        public async Task GetDeveRetornarListaDeDadosClimáticos() 
        {
            var resposta = await _client.GetAsync(EndpointUrl);
            var content = await resposta.Content.ReadAsStringAsync();
            var resultadoConsulta = JsonConvert.DeserializeObject<List<WeatherForecast>>(content);

            resultadoConsulta.Should().NotBeEmpty();        
        }
    }
}
