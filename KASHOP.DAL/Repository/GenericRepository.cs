using Azure.Core;
using KASHOP.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task CreateAsync(T request, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(request, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(T request, int id, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Update(request);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task RemoveAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
            List<Expression<Func<T, object>>>? includes = null,
            bool tracked = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();
            if (!tracked)
                query = query.AsNoTracking();

            if (filter is not null)
                query = query.Where(filter);

            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Set<T>().FindAsync(id, cancellationToken);
            return entity;
        }
    }
}
