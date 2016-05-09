using System;

namespace Desafio.Domain.Entidades
{
    public class Telefone : IEntidade
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public string Numero { get; set; }
        public string DDD { get; set; }
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}