using FluentAssertions;
using NUnit.Framework;
using ValidadorSenha.Api.Dominio.Validadores;

namespace ValidadorSenha.Api.Testes.Unidade.Dominio.Validadores
{
    class SenhaValidadorTestes
    {
        private SenhaValidador _validador;

        [SetUp]
        public void Inicializar() => 
            _validador = new SenhaValidador();

        [Test]
        public void SenhaEstáVálidaDeveRetornarTrueCasoSenhaAtendaTodosOsCritériosTendoNoveCaracteres() 
        {
            const string senha = "Teste@789";
            _validador.SenhaEstáVálida(senha).Should().BeTrue();
        }

        [Test]
        public void SenhaEstáVálidaDeveRetornarTrueCasoSenhaAtendaTodosOsCritériosTendoMaisDeNoveCaracteres()
        {
            const string senha = "TesteSenh@19";
            _validador.SenhaEstáVálida(senha).Should().BeTrue();
        }

        [Test]
        public void SenhaEstáVálidaDeveRetornarTrueCasoSenhaAtendaTodosCritériosEPossuaMultiplosCaracteresEspeciais()
        {
            const string senha = "$Teste%Senh@19&";
            _validador.SenhaEstáVálida(senha).Should().BeTrue();
        }

        [Test]
        public void SenhaEstáVálidaDeveRetornarFalseCasoSenhaTenhaMenosDeNoveCaracteres()
        {
            const string senha = "Teste@78";
            _validador.SenhaEstáVálida(senha).Should().BeFalse();
        }

        [Test]
        public void SenhaEstáVálidaDeveRetornarFalseCasoSenhaNãoTenhaNenhumDígito()
        {
            const string senha = "TesteSemDigitos@";
            _validador.SenhaEstáVálida(senha).Should().BeFalse();
        }

        [Test]
        public void SenhaEstáVálidaDeveRetornarFalseCasoSenhaNãoTenhaNenhumaLetraMinúscula()
        {
            const string senha = "TESTEMAIUSCULO@19";
            _validador.SenhaEstáVálida(senha).Should().BeFalse();
        }

        [Test]
        public void SenhaEstáVálidaDeveRetornarFalseCasoSenhaNãoTenhaNenhumaLetraMaiúscula()
        {
            const string senha = "testeminusculo@19";
            _validador.SenhaEstáVálida(senha).Should().BeFalse();
        }

        [Test]
        public void SenhaEstáVálidaDeveRetornarFalseCasoSenhaNãoTenhaNenhumCaracterEspecial()
        {
            const string senha = "TesteSenha1999";
            _validador.SenhaEstáVálida(senha).Should().BeFalse();
        }
    }
}
