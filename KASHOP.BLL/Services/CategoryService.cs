using Azure;
using KASHOP.DAL.Dto;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryResponse>> GetALlCategories()
        {
            var categories = await _categoryRepository.GetAllAsync(
                new string[] { nameof(Category.Translations) }
                );

            return categories.Adapt<List<CategoryResponse>>();
        }
        public async Task<CategoryResponse> GetCategory(Expression<Func<Category, bool>> filter)
        {
            var category = await _categoryRepository.GetOne(filter, new string[] { nameof(Category.Translations) });
            return category.Adapt<CategoryResponse>();
        }
        public async Task<CategoryResponse> CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            await _categoryRepository.CreateAsync(category);

            return category.Adapt<CategoryResponse>();
        }
        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetOne(c => c.Id == id);
            if (category == null) return false;

            return await _categoryRepository.DeleteAsync(category);
        }
        public async Task<CategoryResponse> UpdateCategory(CategoryRequest request, int id)
        {
            var category = await _categoryRepository.GetOne(c => c.Id == id);
            if (category == null) return null;

            request.Adapt(category);
            await _categoryRepository.UpdateAsync(category);

            return category.Adapt<CategoryResponse>();
        }
    }
}
