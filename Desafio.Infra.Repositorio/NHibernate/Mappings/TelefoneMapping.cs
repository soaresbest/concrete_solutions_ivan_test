using Desafio.Domain.Entidades;

namespace Desafio.Infra.Repositorio.NHibernate.Mappings
{
    public class TelefoneMapping : EntidadeMapping<Telefone>
    {
        public TelefoneMapping()
        {
            Property(x => x.Numero);
            Property(x => x.DDD);

            ManyToOne(x => x.Usuario, map => map.Column("UsuarioId"));
        }
    }
}