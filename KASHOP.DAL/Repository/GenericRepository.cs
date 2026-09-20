using Azure.Core;
using KASHOP.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(T request)
        {
            _context.Set<T>().Add(request);
            _context.SaveChanges();
        }
        public void Update(T request, int id)
        {
            _context.Set<T>().Update(request);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public List<T> GetAll()
        {
            var entities = _context.Set<T>().ToList();
            return entities;
        }
        public T GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            return entity;
        }
    }
}
