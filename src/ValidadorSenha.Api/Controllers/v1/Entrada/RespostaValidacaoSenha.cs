using System.Text.Json.Serialization;

namespace ValidadorSenha.Api.Controllers.v1.Entrada
{
    public class RespostaValidacaoSenha
    {
        [JsonPropertyName("senhaValida")]
        public bool SenhaVálida { get; set; }
    }
}
