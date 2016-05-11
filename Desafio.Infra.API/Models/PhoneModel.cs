using System.ComponentModel.DataAnnotations;
using Desafio.Domain.Entidades;

namespace Desafio.Infra.API.Models
{
    public class PhoneModel : EntityModel
    {
        public PhoneModel()
        {
        }

        public PhoneModel(Telefone telefone)
            : base(telefone)
        {
            Numero = telefone.Numero;
            DDD = telefone.DDD;
        }

        [MaxLength(100)]
        [Required]
        public string Numero { get; set; }

        [MaxLength(100)]
        [Required]
        public string DDD { get; set; }

        public Telefone ToEntity()
        {
            var telefone = new Telefone();

            telefone.Numero = Numero;
            telefone.DDD = DDD;

            return telefone;
        }
    }
}