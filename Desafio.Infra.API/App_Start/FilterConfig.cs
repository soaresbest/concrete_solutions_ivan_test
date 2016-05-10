using System.Web.Http.Filters;

namespace Desafio.Infra.API
{
    public static class FilterConfig
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public static void RegisterWebApiFilters(HttpFilterCollection filters)
        {
            //TODO filtro e autenticação

            //filters.Add(new AuthenticationFilter());
        }
    }
}