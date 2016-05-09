using System;
using Desafio.Domain.Entidades;
using Desafio.Domain.Excecoes;
using Desafio.Domain.Repositorios;
using Desafio.Domain.Servicos;
using Moq;
using NUnit.Framework;

namespace Desafio.Dominio.Test
{
    public class UsuarioServicoTest
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        private Mock<IUsuarioRepositorio> _usuarioRepositorio;
        private UsuarioServico _usuarioServico;

        [SetUp]
        public void SetUp()
        {
            _usuarioRepositorio = new Mock<IUsuarioRepositorio>();

            _usuarioServico = new UsuarioServico(_usuarioRepositorio.Object);
        }

        [Test]
        public void Nao_Permite_Incluir_Usuario_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => _usuarioServico.Incluir(null));
        }

        [Test]
        public void Nao_Permite_Incluir_Usuario_Com_EMail_Previamente_Cadastrado()
        {
            var usuario = new Usuario();

            usuario.EMail = "gmail@chucknorris.com"; // :)

            _usuarioRepositorio
                .Setup(usuarioRepositorio => usuarioRepositorio.ExisteUsuarioComEMail(usuario.EMail))
                .Returns(true);

            Assert.Throws<EMailExistenteException>(() => _usuarioServico.Incluir(usuario));
        }

        [Test]
        public void Deve_Incluir_Usuario()
        {
            _usuarioRepositorio
                .Setup(usuarioRepositorio => usuarioRepositorio.ExisteUsuarioComEMail(It.IsAny<string>()))
                .Returns(false);

            var usuario = new Usuario();

            _usuarioServico.Incluir(usuario);

            _usuarioRepositorio.Verify(usuarioRepositorio => usuarioRepositorio.Incluir(usuario), Times.Once);
        }
    }
}
