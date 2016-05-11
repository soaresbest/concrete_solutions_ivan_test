using System;
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

            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            if (context.Exception is UnauthorizedAccessException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
            }

            var response = new
            {
                statusCode = httpStatusCode,
                mensagem = context.Exception.Message
            };

            context.Response = request.CreateResponse(HttpStatusCode.InternalServerError, response);
        }
    }
}