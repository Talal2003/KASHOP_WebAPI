using KASHOP.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.DAL.Repository
{
    public class GenericRepository<T> where T : class
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
        public void Remove(int id)
        {
            var entity = context.Set<T>().Find(id);
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public List<T> GetAll()
        {
            var entities = context.Set<T>().ToList();
            return entities;
        }
        public T GetById(int id)
        {
            var entity = context.Set<T>().Find(id);
            return entity;
        }
    }
}
