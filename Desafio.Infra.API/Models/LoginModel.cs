using System.ComponentModel.DataAnnotations;
using Desafio.Domain.Entidades;

namespace Desafio.Infra.API.Models
{
    public class LoginModel : EntityModel
    {
        public LoginModel()
        {
        }

        public LoginModel(Usuario usuario)
        {
            EMail = usuario.EMail;
            Senha = usuario.Senha;
        }

        [MaxLength(100)]
        [Required]
        public string EMail { get; set; }

        [MaxLength(100)]
        [Required]
        public string Senha { get; set; }

        public Usuario ToEntity()
        {
            var usuario = new Usuario();

            usuario.EMail = EMail;
            usuario.Senha = Senha;

            return usuario;
        }
    }
}