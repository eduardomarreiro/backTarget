using System.Collections.Generic;
using System.Linq;
using TargetProject.Data;
using TargetProject.Interfaces;
using TargetProject.Models;

namespace TargetProject.Repositories
{
    public class Repository<T> where T : Entity
    {
        public TargetContext _context;

        public Repository(TargetContext context)
        {
            _context = context;

        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Update(T newEntity)
        {
            _context.Set<T>().Update(newEntity);
            _context.SaveChanges();
        }
    }
}
