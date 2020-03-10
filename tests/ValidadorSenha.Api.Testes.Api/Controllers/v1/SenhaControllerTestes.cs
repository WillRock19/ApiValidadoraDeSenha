using FluentAssertions;
using FluentAssertions.Http;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ValidadorSenha.Api.Controllers.v1.Entrada;

namespace ValidadorSenha.Api.Testes.Api.Controllers.v1
{
    class SenhaControllerTestes
    {
        private const string EndpointUrl = "api/v1.0/Senha";
        private HttpClient _client;

        [SetUp]
        public void Inicializar()
            => _client = VariaveisGlobais.HttpClient;

        [Test]
        public async Task PostDeveReceberSenhaStatusCodeOkCasoRequisiçãoDêCerto()
        {
            const string senhaVálida = "S#nh@V@lida!999";
            var conteudoRequisição = CriarConteúdoDaRequisição(senhaVálida);

            var resposta = await _client.PostAsync(EndpointUrl, conteudoRequisição);
            resposta.Should().HaveStatusCode(HttpStatusCode.OK);
        }

        [Test]
        public async Task PostDeveReceberSenhaERetornarTrueCasoSejaVálida() 
        {
            const string senhaVálida = "S#nh@V@lida!999";
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var conteudoRequisição = CriarConteúdoDaRequisição(senhaVálida);
            var resposta = await _client.PostAsync(EndpointUrl, conteudoRequisição);

            var conteudoRetornado = JsonSerializer
                .Deserialize<RespostaValidacaoSenha>(
                    await resposta.Content.ReadAsStringAsync(), options
                );

            conteudoRetornado.Should().NotBeNull();
            conteudoRetornado.SenhaVálida.Should().BeTrue();
        }

        private StringContent CriarConteúdoDaRequisição(string senha) 
        {
            var requisição = new RequisicaoValidarSenha() { Senha = senha };

            return new StringContent(
                JsonSerializer.Serialize(requisição), Encoding.UTF8, MediaTypeNames.Application.Json
            );
        }
    }
}
