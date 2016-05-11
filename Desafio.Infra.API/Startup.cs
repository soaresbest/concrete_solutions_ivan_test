using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Desafio.Infra.API.Security;
using Newtonsoft.Json.Serialization;
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

            ConfigureApiReturnOnlyJson(configuration);

            ConfigureApiReturnLowerCase(configuration);
        }

        private static void ConfigureApiReturnLowerCase(HttpConfiguration configuration)
        {
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }

        private static void ConfigureApiReturnOnlyJson(HttpConfiguration configuration)
        {
            Collection<MediaTypeHeaderValue> mediaTypeHeaderValues = configuration.Formatters.XmlFormatter.SupportedMediaTypes;
            MediaTypeHeaderValue appXmlType = mediaTypeHeaderValues.FirstOrDefault(t => t.MediaType == "application/xml");

            if (null != appXmlType)
            {
                mediaTypeHeaderValues.Remove(appXmlType);
            }
        }
    }
}