using System;

namespace Desafio.Domain.Excecoes
{
    public class SenhaInvalidaException : UnauthorizedAccessException
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public SenhaInvalidaException()
            : base(MontarMensagem())
        {
        }

        private static string MontarMensagem()
        {
            return "Usu�rio e/ou senha inv�lidos.";
        }
    }
}