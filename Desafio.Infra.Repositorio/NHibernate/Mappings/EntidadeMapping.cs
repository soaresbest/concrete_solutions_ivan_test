using Desafio.Domain.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Desafio.Infra.Repositorio.NHibernate.Mappings
{
    public class EntidadeMapping<T> : ClassMapping<T> where T : class, IEntidade
    {
        public EntidadeMapping()
        {
            Id(x => x.Id, g => g.Generator(Generators.GuidComb));

            Property(x => x.DataCriacao);
            Property(x => x.DataAtualizacao);
        }
    }
}