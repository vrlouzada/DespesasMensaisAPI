using Dapper;
using DespesasMensais.Library.Contracts.Repository;
using DespesasMensais.Library.Entities;
using PELEXMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using DTO = DespesasMensais.Library.DTO;

namespace DespesasMensais.DataAccess.Repository
{
    public class UserRepository : Base.Repository, IUserRepository
    {
        public DTO.UserAccount Insert(DTO.UserAccount user)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var entity = MapperUtil.MapIgnoreDependences<UserAccount>(user);
                    user.Id = db.Insert<long, UserAccount>(entity);
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DTO.UserAccount> GetAll()
        {
            try
            {
                using (var db = GetConnection())
                {
                    var users = db.GetList<UserAccount>().ToList();

                    if (users != null)
                    {
                        var response = new List<DTO.UserAccount>();

                        foreach (var user in users)
                        {
                            response.Add(MapperUtil.MapIgnoreDependences<DTO.UserAccount>(user));
                        }
                        return response;
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DTO.UserAccount GetById(long id)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var user = db.Get<UserAccount>(id);

                    if (user != null)
                        return MapperUtil.MapIgnoreDependences<DTO.UserAccount>(user);

                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(DTO.UserAccount user)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var entity = MapperUtil.MapIgnoreDependences<UserAccount>(user);
                    var response = db.Update(entity);
                    return response > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DTO.UserAccount CheckUser(DTO.AuthenticateRequest model)
        {
            try
            {
                using (var db = GetConnection())
                {
                    var SQL = $"SELECT * FROM UserAccount WHERE UserName = '{model.Username}' and Password = '{model.Password}'";
                    var user = db.QueryFirstOrDefault<DTO.UserAccount>(SQL);

                    if (user != null)
                        return MapperUtil.MapIgnoreDependences<DTO.UserAccount>(user);

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
