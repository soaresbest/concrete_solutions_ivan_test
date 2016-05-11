using System;
using Desafio.Domain.Entidades;

namespace Desafio.Infra.API.Models
{
    public class EntityModel
    {
        public EntityModel()
        {
        }

        public EntityModel(IEntidade entidade)
        {
            Id = entidade.Id;
            DataCriacao = entidade.DataCriacao;
            DataAtualizacao = entidade.DataAtualizacao;
        }

        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}