using FluentAssertions;
using FluentAssertions.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
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
            var conteudoRequisição = CriarConteúdoDaRequisição(senhaVálida);

            var resposta = await _client.PostAsync(EndpointUrl, conteudoRequisição);
            var conteudoRetornado = JsonConvert
                .DeserializeObject<RespostaValidacaoSenha>(await resposta.Content.ReadAsStringAsync());

            conteudoRetornado.Should().NotBeNull();
            conteudoRetornado.SenhaVálida.Should().BeTrue();
        }

        private StringContent CriarConteúdoDaRequisição(string senha) 
        {
            var requisição = new RequisicaoValidarSenha() { Senha = senha };

            return new StringContent(
                JsonConvert.SerializeObject(requisição), Encoding.UTF8, MediaTypeNames.Application.Json
            );
        }
    }
}
