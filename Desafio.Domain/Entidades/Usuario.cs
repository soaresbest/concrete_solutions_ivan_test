using System.Collections.Generic;

namespace Desafio.Domain.Entidades
{
    public class Usuario
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Senha { get; set; }
        public IList<Telefone> Telefones { get; set; }
    }
}
