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

        private const string E_MAIL = "gmail@chucknorris.com"; // :)

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

            usuario.EMail = E_MAIL;

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

        [Test]
        public void Nao_Permite_Login_De_Usuario_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => _usuarioServico.Login(null));
        }

        [Test]
        public void Lancar_EMailInexistenteException_Para_Usuario_Nao_Encontrado_Pelo_Email()
        {
            _usuarioRepositorio
                .Setup(usuarioRepositorio => usuarioRepositorio.CarregarPorEMail(E_MAIL))
                .Returns((Usuario) null);

            var usuario = new Usuario();

            Assert.Throws<EMailInexistenteException>(() => _usuarioServico.Login(usuario));
        }

        [Test]
        public void Lancar_SenhaInvalidaException_Para_Usuario_Encontrado_Pelo_Email_Mas_Senha_Incompativel()
        {
            var usuario = new Usuario
            {
                EMail = E_MAIL,
                Senha = "pass@123"
            };

            var usuarioPorEMail = new Usuario
            {
                EMail = E_MAIL,
                Senha = "pass!123"
            };

            _usuarioRepositorio
                .Setup(usuarioRepositorio => usuarioRepositorio.CarregarPorEMail(E_MAIL))
                .Returns(usuarioPorEMail);

            Assert.Throws<SenhaInvalidaException>(() => _usuarioServico.Login(usuario));
        }

        [Test]
        public void Alterar_Atributo_UltimoLogin_Se_Usuario_For_Encontrado_E_Senha_Coincidir()
        {
            var now = DateTime.Now;

            var usuario = new Usuario
            {
                EMail = E_MAIL,
                Senha = "pass@123",
                UltimoLogin = now
            };

            var usuarioPorEMail = new Usuario
            {
                EMail = E_MAIL,
                Senha = "pass@123",
                UltimoLogin = now
            };

            _usuarioRepositorio
                .Setup(usuarioRepositorio => usuarioRepositorio.CarregarPorEMail(E_MAIL))
                .Returns(usuarioPorEMail);

            _usuarioServico.Login(usuario);

            Assert.Greater(usuarioPorEMail.UltimoLogin, usuario.UltimoLogin);
        }

        [Test]
        public void Deve_Chamar_Repositorio_Para_Alterar_Ultimologin_Do_Usuario()
        {
            var usuario = new Usuario
            {
                EMail = E_MAIL,
                Senha = "pass@123"
            };

            var usuarioPorEMail = new Usuario
            {
                EMail = E_MAIL,
                Senha = "pass@123"
            };

            _usuarioRepositorio
                .Setup(usuarioRepositorio => usuarioRepositorio.CarregarPorEMail(E_MAIL))
                .Returns(usuarioPorEMail);

            _usuarioServico.Login(usuario);

            _usuarioRepositorio.Verify(usuarioRepositorio => usuarioRepositorio.Alterar(usuarioPorEMail), Times.Once);
        }
    }
}
