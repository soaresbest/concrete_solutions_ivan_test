using System.Web;
using System.Web.Http;

namespace Desafio.Infra.API
{
    public class WebApiApplication : HttpApplication
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        protected void Application_Start()
        {
            InjectorConfig.Configure();

            FilterConfig.RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
