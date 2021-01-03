using System.Collections.Generic;

namespace DespesasMensais.Library.Contracts.Repository
{
    public interface IUserRepository
    {
        DTO.UserAccount CheckUser(DTO.AuthenticateRequest model);
        List<DTO.UserAccount> GetAll();
        DTO.UserAccount GetById(long id);
        DTO.UserAccount Insert(DTO.UserAccount user);
        bool Update(DTO.UserAccount user);
    }
}
