using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KASHOP.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T request, CancellationToken cancellationToken = default);
        Task UpdateAsync(T request, int id, CancellationToken cancellationToken = default);
        Task RemoveAsync(int id, CancellationToken cancellationToken = default);
        Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null, List<Expression<Func<T, object>>>? includes = null, bool tracked = false, CancellationToken cancellationToken = default);
        Task<T?> GetOneAsync(Expression<Func<T, bool>>? filter = null, List<Expression<Func<T, object>>>? includes = null, bool tracked = false, CancellationToken cancellationToken = default);
    }
}
