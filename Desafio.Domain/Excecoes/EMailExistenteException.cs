namespace Desafio.Domain.Excecoes
{
    public class EMailExistenteException : DominioException
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        public EMailExistenteException(string eMail)
            : base(MontarMensagem(eMail))
        {
        }

        private static string MontarMensagem(string eMail)
        {
            return string.Format("E-mail '{0}' já existente.", eMail);
        }
    }
}
