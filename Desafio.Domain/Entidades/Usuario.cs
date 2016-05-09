using System;
using System.Collections.Generic;

namespace Desafio.Domain.Entidades
{
    public class Usuario : IEntidade
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Senha { get; set; }
        public DateTime UltimoLogin { get; set; }
        public string Token { get; set; }
        public IList<Telefone> Telefones { get; set; }
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
