using System.ComponentModel.DataAnnotations;

namespace Desafio.Infra.API.Models
{
    public class AudienceModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}