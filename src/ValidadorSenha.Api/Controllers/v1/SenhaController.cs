using Microsoft.AspNetCore.Mvc;
using ValidadorSenha.Api.Controllers.v1.Entrada;
using ValidadorSenha.Api.Dominio.Validadores;

namespace ValidadorSenha.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SenhaController : ControllerBase
    {
        private readonly SenhaValidador _senhaValidador;

        public SenhaController(SenhaValidador senhaValidador)
        {
            _senhaValidador = senhaValidador;
        }

        [HttpPost]
        public ActionResult<bool> ValidarSenha([FromBody] RequisicaoValidarSenha requisição)
        {
            var senhaVálida = _senhaValidador.SenhaEstáVálida(requisição.Senha);
            return Ok(new RespostaValidacaoSenha { SenhaVálida = senhaVálida });
        }
    }
}