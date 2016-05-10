using Desafio.Domain.Entidades;
using NHibernate.Mapping.ByCode;

namespace Desafio.Infra.Repositorios.NHibernate.Mappings
{
    public class UsuarioMapping : EntidadeMapping<Usuario>
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public UsuarioMapping()
        {
            Property(x => x.Nome);
            Property(x => x.EMail);
            Property(x => x.Senha);
            Property(x => x.UltimoLogin);
            Property(x => x.Token);

            Bag(x => x.Telefones, map =>
            {
                map.Cascade(Cascade.All.Include(Cascade.DeleteOrphans));
                map.Access(Accessor.NoSetter);
                map.Key(key => key.Column("UsuarioId"));
            }, map => map.OneToMany());
        }
    }
}
