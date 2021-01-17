using DespesasMensais.Library.DTO;

namespace DespesasMensais.Library.Contracts.Service
{
    public interface IAccountService
    {
        /// <summary>
        /// Serviço responsável pela autenticação e geração do token
        /// </summary>
        /// <param name="model">objeto que contém o login e senha do usuário</param>
        /// <returns></returns>
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
