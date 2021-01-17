using DespesasMensais.Library.DTO;

namespace DespesasMensais.Library.Contracts.Repository
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Método responsável por verificar se o login e senha estão cadastrados no banco
        /// </summary>
        /// <param name="model">Objeto de modelo para autenticação</param>
        /// <returns>Usuário vinculado ao login e senha</returns>
        UserAccount Authenticate(AuthenticateRequest model);
    }
}
