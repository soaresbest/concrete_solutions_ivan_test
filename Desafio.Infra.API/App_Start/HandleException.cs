using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Desafio.Infra.API
{
    public class HandleException : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpRequestMessage request = context.ActionContext.Request;

            var response = new
            {
                statusCode = HttpStatusCode.InternalServerError,
                mensagem = context.Exception.Message
            };

            context.Response = request.CreateResponse(HttpStatusCode.InternalServerError, response);
        }
    }
}