using KASHOP.DAL.Dto;
using KASHOP.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Models;
using Azure;

namespace KASHOP.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryResponse> CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            await _categoryRepository.CreateAsync(category);

            var response = category.Adapt<CategoryResponse>();

            return response;
        }
        public async Task<List<CategoryResponse>> GetALlCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var response = categories.Adapt<List<CategoryResponse>>();

            return response;
        }
    }
}
