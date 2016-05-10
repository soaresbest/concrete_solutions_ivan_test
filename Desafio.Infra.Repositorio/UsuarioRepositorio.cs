using Desafio.Domain.Entidades;
using Desafio.Domain.Repositorios;
using NHibernate;
using NHibernate.Criterion;

namespace Desafio.Infra.Repositorios
{
    public class UsuarioRepositorio : Repositorio, IUsuarioRepositorio
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public UsuarioRepositorio(ISession session)
            : base(session)
        {
        }

        public bool ExisteUsuarioComEMail(string eMail)
        {
            long count;

            using (ITransaction transaction = Session.BeginTransaction())
            {
                count = Session
                    .CreateCriteria<Usuario>()
                    .SetProjection(Projections.RowCountInt64())
                    .UniqueResult<long>();

                transaction.Commit();
            }

            return count > 0;
        }
    }
}