﻿using System;
using System.Linq;
using Desafio.Domain.Entidades;
using Desafio.Domain.Excecoes;
using Desafio.Domain.Repositorios;

namespace Desafio.Domain.Servicos
{
    public class UsuarioServico
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void Incluir(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException("usuario");

            if (_usuarioRepositorio.ExisteUsuarioComEMail(usuario.EMail))
                throw new EMailExistenteException(usuario.EMail);

            DateTime now = DateTime.Now;

            usuario.DataCriacao = now;
            usuario.DataAtualizacao = now;
            usuario.UltimoLogin = now;

            if (usuario.Telefones != null && usuario.Telefones.Any())
            {
                foreach (Telefone telefone in usuario.Telefones)
                {
                    telefone.DataCriacao = now;
                    telefone.DataAtualizacao = now;
                }
            }

            _usuarioRepositorio.Incluir(usuario);
        }
    }
}
