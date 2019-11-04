using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class EventRepository : IRepository<Event>
    {
        private readonly ProjectDbContext _context;
        public EventRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public void Create(Event entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Event entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events;
        }

        public Event GetById(int id)
        {
            return _context.Events.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Event entity)
        {
          var change = _context.Events.FirstOrDefault(x => x.Id ==entity.Id);
            if(change != null)
            {
                change = entity;
                _context.SaveChanges();
            }
        }
    }
}
