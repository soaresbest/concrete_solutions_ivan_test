using System;
using Desafio.Domain.Entidades;

namespace Desafio.Domain.Repositorios
{
    public interface IRepositorio
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         * 
         * Extender este repositório se houver necessidade
         * de operações para entidades específicas.
         */

        void Incluir(IEntidade entidade);
        void Alterar(IEntidade entidade);
        TEntidade Carregar<TEntidade>(Guid id) where TEntidade : IEntidade;
    }
}
