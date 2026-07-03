using KASHOP.DAL.Dto;
using KASHOP.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<CategoryResponse> GetALlCategories()
        {
            var categories = _categoryRepository.GetAll();
            var response =categories.Adapt
        }
    }
}
