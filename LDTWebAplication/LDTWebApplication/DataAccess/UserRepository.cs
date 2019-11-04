using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly ProjectDbContext _context;
        public UserRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public void Create(User entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.ID == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Update(User entity)
        {
      
          var change =  _context.Users.FirstOrDefault(x => x.ID == entity.ID);
            if(change != null )
            {
                change = entity;
                _context.SaveChanges();
            }
        }
    }
}
