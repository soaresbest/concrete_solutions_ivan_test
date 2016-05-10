using System.Web.Http;
using CommonServiceLocator.SimpleInjectorAdapter;
using Desafio.Domain.Repositorios;
using Desafio.Domain.Servicos;
using Desafio.Infra.Repositorios;
using Desafio.Infra.Repositorios.NHibernate;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
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

        public static void Configure()
        {
            var container = new Container();

            container.RegisterSingleton<ISessionFactory>(SessionFactoryHelper.GetSessionFactory);

            container.RegisterWebApiRequest<ISession>(() => container.GetInstance<ISessionFactory>().OpenSession());

            container.RegisterWebApiRequest<IRepositorio, Repositorio>();
            container.RegisterWebApiRequest<IUsuarioRepositorio, UsuarioRepositorio>();

            container.RegisterWebApiRequest<UsuarioServico, UsuarioServico>();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            IServiceLocator serviceLocator = new SimpleInjectorServiceLocatorAdapter(container);

            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}