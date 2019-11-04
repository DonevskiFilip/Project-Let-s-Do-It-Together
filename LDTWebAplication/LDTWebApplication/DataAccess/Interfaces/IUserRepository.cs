using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
   public interface IUserRepository<TUser> where TUser : User
    {
        IEnumerable<TUser> GetAll();
        TUser GetById(int id);
        TUser GetByUsername(string username);
        void Create(TUser entity);
        void Update(TUser entity);
        void Delete(TUser entitiy);

    }
}
