using Hotel.ProjectDataAccessLayer.Abstract;
using Hotel.ProjectDataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ProjectDataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            Save();
        }
    }
}
