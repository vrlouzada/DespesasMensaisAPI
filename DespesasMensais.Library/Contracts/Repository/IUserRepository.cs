using System.Collections.Generic;

namespace DespesasMensais.Library.Contracts.Repository
{
    public interface IUserRepository
    {
        List<DTO.UserAccount> GetAll();
        DTO.UserAccount GetById(long id);
        DTO.UserAccount Insert(DTO.UserAccount user);
        bool Update(DTO.UserAccount user);
    }
}
