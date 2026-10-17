using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repo;
        public CategoryService(IGenericRepository<Category> repo)
        {
            _repo = repo;
        } 
        public async Task<bool> CreateAsync(CategoryRequest request)
        {
            var categories = await _repo.GetAllAsync();
            var exists = categories.Any(c=>c.Name.ToLower() == request.Name.ToLower());
            if (exists) return false;

            var category = request.Adapt<Category>();
            await _repo.CreateAsync(category);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categories = await _repo.GetAllAsync();
            var exists = categories.Any(c => c.Id == id);
            if (!exists) return false;

            await _repo.RemoveAsync(id);
            return true;
        }

        public async Task<List<CategoryResponse>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return categories.Adapt<List<CategoryResponse>>();
        }

        public async Task<CategoryResponse?> GetByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            return category.Adapt<CategoryResponse>();
        }

        public async Task<bool> UpdateAsync(CategoryRequest request, int id)
        {
            var categories = await _repo.GetAllAsync();
            var exists = categories.Any(c => c.Id == id);
            if (!exists) return false;

            var category = request.Adapt<Category>();
            await _repo.UpdateAsync(category, id);
            return true;
        }
    }
}
