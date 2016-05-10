using System;

namespace Desafio.Domain.Entidades
{
    public class Telefone : IEntidade
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public virtual Usuario Usuario { get; set; }
        public virtual string Numero { get; set; }
        public virtual string DDD { get; set; }
        public virtual Guid Id { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime DataAtualizacao { get; set; }
    }
}