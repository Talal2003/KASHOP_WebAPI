using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetAllAsync();
        Task<CategoryResponse?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CategoryRequest request);
        Task<bool> UpdateAsync(CategoryRequest request, int id);
        Task<bool> DeleteAsync(int id);
    }
}
