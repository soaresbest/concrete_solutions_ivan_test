namespace Desafio.Domain.Repositorios
{
    public interface IUsuarioRepositorio: IRepositorio
    {
        /*
         * Desafio .NET Concrete Solutions
         * Ivan Soares dos Santos
         */

        bool ExisteUsuarioComEMail(string eMail);
    }
}