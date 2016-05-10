using Desafio.Domain.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Desafio.Infra.Repositorios.NHibernate.Mappings
{
    public class EntidadeMapping<T> : ClassMapping<T> where T : class, IEntidade
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public EntidadeMapping()
        {
            Id(x => x.Id, g => g.Generator(Generators.GuidComb));

            Property(x => x.DataCriacao);
            Property(x => x.DataAtualizacao);
        }
    }
}