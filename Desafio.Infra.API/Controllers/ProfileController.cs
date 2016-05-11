using System;
using System.Web.Http;
using Desafio.Domain.Entidades;
using Desafio.Domain.Excecoes;
using Desafio.Domain.Repositorios;
using Desafio.Infra.API.Models;

namespace Desafio.Infra.API.Controllers
{
    [RoutePrefix("api/profile")]
    public class ProfileController : ApiController
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ProfileController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [Route("")]
        public IHttpActionResult Get([FromUri] string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
            {
                return BadRequest();
            }

            Usuario usuario = _usuarioRepositorio.Carregar<Usuario>(guid);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok<UserModel>(new UserModel(usuario));
        }
    }
}
