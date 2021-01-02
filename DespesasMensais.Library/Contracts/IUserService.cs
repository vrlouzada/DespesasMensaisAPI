using DespesasMensais.Library.Entities;
using DespesasMensais.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespesasMensais.Library.Contracts
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserAccount> GetAll();
        UserAccount GetById(long id);
    }
}
