using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task CreateAsync(T request);
        Task UpdateAsync(T request, int id);
        Task RemoveAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
