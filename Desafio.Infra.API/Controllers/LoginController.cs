using System.Web.Http;
using Desafio.Domain.Entidades;
using Desafio.Domain.Servicos;
using Desafio.Infra.API.Models;

namespace Desafio.Infra.API.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private readonly UsuarioServico _usuarioServico;

        public LoginController(UsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [Route("")]
        public IHttpActionResult Post(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = loginModel.ToEntity();

            usuario = _usuarioServico.Login(usuario);

            return Ok<UserModel>(new UserModel(usuario));
        }
    }
}