using System.Web.Http;
using Desafio.Domain.Entidades;
using Desafio.Domain.Servicos;
using Desafio.Infra.API.Models;

namespace Desafio.Infra.API.Controllers
{
    [RoutePrefix("api/signup")]
    public class SignUpController : ApiController
    {
        private readonly UsuarioServico _usuarioServico;

        public SignUpController(UsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [Route("")]
        public IHttpActionResult Post(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = userModel.ToEntity();

            _usuarioServico.Incluir(usuario);

            return Ok<UserModel>(new UserModel(usuario));
        }
    }
}
