using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class UserEventRepository : IRepository<UserEvents>
    {
        private readonly ProjectDbContext _context;
        public UserEventRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public void Create(UserEvents entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(UserEvents entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<UserEvents> GetAll()
        {
            return _context.UserEvents;
        }

        public UserEvents GetById(int id)
        {
            return _context.UserEvents.FirstOrDefault(x => x.ID == id);
        }

        public void Update(UserEvents entity)
        {
            throw new NotImplementedException();
        }
    }
}
