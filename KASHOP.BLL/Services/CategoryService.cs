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
        public bool Create(CategoryRequest request)
        {
            var exists = _repo.GetAll().Any(c=>c.Name.ToLower() == request.Name.ToLower());
            if (exists) return false;

            var category = request.Adapt<Category>();
            _repo.Create(category);
            return true;
        }

        public bool Delete(int id)
        {
            var exists = _repo.GetAll().Any(c => c.Id == id);
            if (!exists) return false;

            _repo.Remove(id);
            return true;
        }

        public List<CategoryResponse> GetAll()
        {
            var categories = _repo.GetAll();
            return categories.Adapt<List<CategoryResponse>>();
        }

        public CategoryResponse? GetById(int id)
        {
            var category = _repo.GetById(id);
            return category.Adapt<CategoryResponse>();
        }

        public bool Update(int id, CategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
