using System;
using System.Collections.Generic;
using System.Linq;
using Desafio.Infra.Repositorios.NHibernate.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace Desafio.Infra.Repositorios.NHibernate
{
    public static class SessionFactoryHelper
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public static ISessionFactory GetSessionFactory()
        {
            var configuration = new Configuration();
            var modelMapper = new ModelMapper();

            configuration.DataBaseIntegration(c =>
            {
                c.ConnectionStringName = "DesafioIvan";
                c.Driver<SQLite20Driver>();
                c.Dialect<SQLiteDialect>();
            });

            List<Type> types = typeof(EntidadeMapping<>)
                .Assembly
                .GetTypes()
                .ToList();

            //types.Remove(typeof(SessionFactoryHelper));

            modelMapper.AddMappings(types);

            HbmMapping mappings = modelMapper.CompileMappingForAllExplicitlyAddedEntities();

            configuration.AddMapping(mappings);

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();

            return sessionFactory;
        }
    }
}
