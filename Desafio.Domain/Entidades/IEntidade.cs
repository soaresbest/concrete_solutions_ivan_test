using System;

namespace Desafio.Domain.Entidades
{
    public interface IEntidade
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         * 
         * Datas de criação e atualização, segundo a documentação
         * do desafio, devem ser para o usuário, mas foi estendido
         * para todas as entidades.
         */

        Guid Id { get; set; }
        DateTime DataCriacao { get; set; }
        DateTime DataAtualizacao { get; set; }
    }
}