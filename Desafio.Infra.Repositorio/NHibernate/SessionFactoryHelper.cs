using Desafio.Infra.Repositorios.NHibernate.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using Configuration = NHibernate.Cfg.Configuration;

namespace Desafio.Infra.Repositorios.NHibernate
{
    public static class SessionFactoryHelper
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         * 
         * Utilizando o NHibernate com SQLite.
         */

        private const string CONNECTION_STRING_NAME = "DesafioIvan";

        public static Configuration Configuration { get; private set; }

        public static ISessionFactory GetSessionFactory()
        {
            Configuration = new Configuration();
            var modelMapper = new ModelMapper();

            Configuration.DataBaseIntegration(c =>
            {
                c.ConnectionStringName = CONNECTION_STRING_NAME;
                c.Driver<SQLite20Driver>();
                c.Dialect<SQLiteDialect>();

                /*
                 * Com o banco de dados na memória no SQLite a estrutura se perde
                 * ao fechar a conexão e isso acontece a cada transação, a não ser
                 * que a configuração abaixo seja mantida.
                 */
                c.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
            });

            modelMapper.AddMapping<UsuarioMapping>();
            modelMapper.AddMapping<TelefoneMapping>();

            HbmMapping mappings = modelMapper.CompileMappingForAllExplicitlyAddedEntities();

            Configuration.AddMapping(mappings);

            ISessionFactory sessionFactory = Configuration.BuildSessionFactory();

            return sessionFactory;
        }
    }
}
