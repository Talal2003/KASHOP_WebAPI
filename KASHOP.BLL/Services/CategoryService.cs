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
        public async Task<bool> CreateAsync(CategoryRequest request, CancellationToken cancellationToken = default)
        {
            var existing = await _repo.GetOneAsync(
                filter: c => c.Name.ToLower() == request.Name.ToLower(),
                cancellationToken: cancellationToken
                );

            if (existing != null) return false;

            var category = request.Adapt<Category>();
            await _repo.CreateAsync(category, cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var categories = await _repo.GetAsync(cancellationToken: cancellationToken);
            var exists = categories.Any(c => c.Id == id);
            if (!exists) return false;

            await _repo.RemoveAsync(id, cancellationToken);
            return true;
        }

        public async Task<List<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repo.GetAsync(cancellationToken: cancellationToken);
            return categories.Adapt<List<CategoryResponse>>();
        }

        public async Task<CategoryResponse?> GetByIdAsync(CancellationToken cancellationToken = default)
        {
            var category = await _repo.GetOneAsync(cancellationToken: cancellationToken);
            return category.Adapt<CategoryResponse>();
        }

        public async Task<bool> UpdateAsync(CategoryRequest request, int id, CancellationToken cancellationToken = default)
        {
            var categories = await _repo.GetAsync(cancellationToken:cancellationToken);
            var exists = categories.Any(c => c.Id == id);
            if (!exists) return false;

            var category = request.Adapt<Category>();
            await _repo.UpdateAsync(category, id, cancellationToken);
            return true;
        }
    }
}
