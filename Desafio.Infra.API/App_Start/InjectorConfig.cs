using System;
using System.Web.Http;
using CommonServiceLocator.SimpleInjectorAdapter;
using Desafio.Domain.Repositorios;
using Desafio.Domain.Servicos;
using Desafio.Infra.Repositorios;
using Desafio.Infra.Repositorios.NHibernate;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Desafio.Infra.API
{
    public static class InjectorConfig
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public static void Configure(HttpConfiguration configuration)
        {
            var container = new Container();

            container.RegisterSingleton<ISessionFactory>(SessionFactoryHelper.GetSessionFactory);

            /*
             * Normalmente não se registra uma sessão singleton.
             * Neste caso foi necessário pois o banco de dados no SQLite
             * dura somente enquanto a conexão existir.
             */
            container.RegisterSingleton<ISession>(() =>
            {
                ISession session = container.GetInstance<ISessionFactory>().OpenSession();

                BuildDatabase(session);

                return session;
            });

            container.RegisterWebApiRequest<IRepositorio, Repositorio>();
            container.RegisterWebApiRequest<IUsuarioRepositorio, UsuarioRepositorio>();

            container.RegisterWebApiRequest<UsuarioServico>();

            container.RegisterWebApiControllers(configuration);

            container.Verify();

            IServiceLocator serviceLocator = new SimpleInjectorServiceLocatorAdapter(container);

            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void BuildDatabase(ISession session)
        {
            /*
             * As 3 linhas abaixo deveriam ser executadas no banco de dados,
             * mas não aconteceu como esperado.
             * A solução foi executar diretamente no banco, comando a comando.
             */

            //var schemaExport = new SchemaExport(SessionFactoryHelper.Configuration);
            //schemaExport.SetDelimiter(";");
            //schemaExport.Create(useStdOut: true, execute: true);

            var schemaExport = new SchemaExport(SessionFactoryHelper.Configuration);

            schemaExport.SetDelimiter(";");

            string output = string.Empty;
            schemaExport.Create((sql) => output += sql, true);

            string[] statements = output.Split(';');
            foreach (string statement in statements)
            {
                if (string.IsNullOrWhiteSpace(statement))
                {
                    continue;
                }

                session
                    .CreateSQLQuery(statement)
                    .ExecuteUpdate();
            }
        }
    }
}