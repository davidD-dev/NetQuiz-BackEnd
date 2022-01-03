using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Context;

namespace WebApplication3.Repository
{
    public class CrudRepository<T> : ICrudRepository<T> where T : EntityWithId
    {
        private AppDbContext _context = null;
        private DbSet<T> table = null;
        public CrudRepository(AppDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }


        public T GetById(Guid id)
        {
            return table.Find(id);
        }



        public T Insert(T obj)
        {
            return table.Add(obj).Entity;
        }
        public void Delete(Guid id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Update(T obj)
        {
            _context.Update(obj);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
