using System;

namespace Desafio.Domain.Excecoes
{
    public class EMailInexistenteException : UnauthorizedAccessException
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public EMailInexistenteException()
            : base(MontarMensagem())
        {
        }

        private static string MontarMensagem()
        {
            return "Usu�rio e/ou senha inv�lidos.";
        }
    }
}