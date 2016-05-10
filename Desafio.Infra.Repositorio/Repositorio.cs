using System;
using Desafio.Domain.Entidades;
using Desafio.Domain.Repositorios;
using NHibernate;

namespace Desafio.Infra.Repositorio
{
    public class Repositorio : IRepositorio
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        protected ISession Session;

        public Repositorio(ISession session)
        {
            Session = session;
        }

        public void Incluir(IEntidade entidade)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.Save(entidade);

                transaction.Commit();
            }
        }

        public TEntidade Carregar<TEntidade>(Guid id) where TEntidade : IEntidade
        {
            TEntidade entidade;

            using (ITransaction transaction = Session.BeginTransaction())
            {
                entidade = Session.Get<TEntidade>(id);

                transaction.Commit();
            }

            return entidade;
        }
    }
}
