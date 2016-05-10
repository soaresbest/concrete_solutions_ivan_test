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

        public virtual string Nome { get; set; }
        public virtual string EMail { get; set; }
        public virtual string Senha { get; set; }
        public virtual DateTime UltimoLogin { get; set; }
        public virtual string Token { get; set; }
        public virtual IList<Telefone> Telefones { get; set; }
        public virtual Guid Id { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime DataAtualizacao { get; set; }
    }
}
