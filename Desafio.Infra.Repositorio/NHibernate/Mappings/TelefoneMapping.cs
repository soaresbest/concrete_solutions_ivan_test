using Desafio.Domain.Entidades;

namespace Desafio.Infra.Repositorios.NHibernate.Mappings
{
    public class TelefoneMapping : EntidadeMapping<Telefone>
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public TelefoneMapping()
        {
            Property(x => x.Numero);
            Property(x => x.DDD);

            ManyToOne(x => x.Usuario, map => map.Column("UsuarioId"));
        }
    }
}