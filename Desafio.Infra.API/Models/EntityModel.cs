using System;
using Desafio.Domain.Entidades;
using Newtonsoft.Json;

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

        [JsonProperty("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [JsonProperty("data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}