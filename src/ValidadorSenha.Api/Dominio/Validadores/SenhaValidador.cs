using System.Linq;
using System.Text.RegularExpressions;

namespace ValidadorSenha.Api.Dominio.Validadores
{
    public class SenhaValidador
    {
        public bool SenhaEstáVálida(string senha) 
            => PossuiNoveOuMaisCaracteres(senha)
            && PossuiAoMenosUmDígito(senha) 
            && PossuiAoMenosUmaLetraMaiúscula(senha)
            && PossuiAoMenosUmaLetraMinúscula(senha) 
            && PossuiAoMenosUmCaracterEspecial(senha);

        private bool PossuiAoMenosUmDígito(string senha)
            => senha.Any(caracter => char.IsDigit(caracter));

        private bool PossuiAoMenosUmaLetraMaiúscula(string senha)
            => senha.Any(caracter => char.IsUpper(caracter));

        private bool PossuiAoMenosUmaLetraMinúscula(string senha)
            => senha.Any(caracter => char.IsLower(caracter));

        private bool PossuiAoMenosUmCaracterEspecial(string senha)
        {
            var patternCaracteresEspeciais = @".*([\|!#$%&\/()=?»«@£§€{}.\-;'<>_,]+).*$";
            return Regex.IsMatch(senha, patternCaracteresEspeciais);
        }

        private bool PossuiNoveOuMaisCaracteres(string senha)
            => !string.IsNullOrEmpty(senha) && senha.Length >= 9;
    }
}
