using Dapper;
using DespesasMensais.Library.Contracts.Repository;
using DespesasMensais.Library.DTO;
using PELEXMapper;
using System;
using Model = DespesasMensais.Library.Entities;

namespace DespesasMensais.DataAccess.Repository
{
    public class AccountRepository : Base.Repository, IAccountRepository
    {
        public UserAccount Authenticate(AuthenticateRequest model)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var SQL = $"SELECT * FROM UserAccount WHERE UserName = '{model.Username}' and Password = '{model.Password}'";
                    var user = db.QueryFirstOrDefault<Model.UserAccount>(SQL);

                    if (user != null)
                        return MapperUtil.MapIgnoreDependences<UserAccount>(user);

                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
