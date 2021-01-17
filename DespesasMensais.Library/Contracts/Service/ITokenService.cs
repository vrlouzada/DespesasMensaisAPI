using DespesasMensais.Library.DTO;

namespace DespesasMensais.Library.Contracts.Service
{
    public interface ITokenService
    {
        /// <summary>
        /// Método responsável pela criação do token
        /// </summary>
        /// <param name="user">usuário autenticado</param>
        /// <returns></returns>
        string GenerateToken(UserAccount user);
    }
}
