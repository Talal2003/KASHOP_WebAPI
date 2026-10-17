using Azure.Core;
using KASHOP.DAL.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAsync(T request)
        {
            await _context.Set<T>().AddAsync(request);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T request, int id)
        {
            _context.Set<T>().Update(request);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync()
        {
            var entities = await _context.Set<T>().AsNoTracking().ToListAsync();
            return entities;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }
    }
}
