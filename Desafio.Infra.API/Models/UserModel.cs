using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Desafio.Domain.Entidades;
using Newtonsoft.Json;

namespace Desafio.Infra.API.Models
{
    public class UserModel : EntityModel
    {
        public UserModel()
        {
        }

        public UserModel(Usuario usuario)
            : base(usuario)
        {
            Nome = usuario.Nome;
            EMail = usuario.EMail;
            Senha = usuario.Senha;
            UltimoLogin = usuario.UltimoLogin;

            if (usuario.Telefones != null && usuario.Telefones.Any())
            {
                Telefones = new List<PhoneModel>();

                foreach (Telefone telefone in usuario.Telefones)
                {
                    Telefones.Add(new PhoneModel(telefone));
                }
            }
        }

        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(100)]
        [Required]
        [JsonProperty("email")]
        public string EMail { get; set; }

        [MaxLength(100)]
        [Required]
        public string Senha { get; set; }

        [JsonProperty("ultimo_login")]
        public DateTime UltimoLogin { get; set; }

        public IList<PhoneModel> Telefones { get; set; }

        public Usuario ToEntity()
        {
            var usuario = new Usuario();

            usuario.Nome = Nome;
            usuario.EMail = EMail;
            usuario.Senha = Senha;

            if (Telefones != null && Telefones.Any())
            {
                usuario.Telefones = new List<Telefone>();

                foreach (PhoneModel phoneModel in Telefones)
                {
                    usuario.Telefones.Add(phoneModel.ToEntity());
                }
            }

            return usuario;
        }
    }
}