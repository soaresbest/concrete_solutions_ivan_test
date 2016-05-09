using System;

namespace Desafio.Domain.Excecoes
{
    public class DominioException : Exception
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public DominioException(string message)
            : base(message)
        {
        }
    }
}
