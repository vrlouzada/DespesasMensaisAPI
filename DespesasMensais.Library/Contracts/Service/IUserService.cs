using DespesasMensais.Library.Entities;
using DTO = DespesasMensais.Library.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespesasMensais.Library.Contracts
{
    public interface IUserService
    {
        DTO.AuthenticateResponse Authenticate(DTO.AuthenticateRequest model);
        IEnumerable<DTO.UserAccount> GetAll();
        DTO.UserAccount GetById(long id);
        DTO.UserAccount Register(DTO.UserAccount newUser);
    }
}
