using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Desafio.Infra.API.Security;
using Owin;

namespace Desafio.Infra.API
{
    public class Startup
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         * 
         * Setup do OWIN e da API
         */

        public void Configuration(IAppBuilder app)
        {
            /*
             * Método executado ao inicializar o servidor
             * definido no arquivo AssemblyInfo.cs
             */

            HttpConfiguration configuration = new HttpConfiguration();

            InjectorConfig.Configure(configuration);

            OAuth.Configure(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(configuration);

            configuration.MapHttpAttributeRoutes();

            configuration.Filters.Add(new HandleException());
            
            FilterConfig.RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);
        }
    }
}