using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Services
{
    public interface ICategoryService
    {
        List<CategoryResponse> GetAll();
        CategoryResponse? GetById(int id);
        bool Create(CategoryRequest request);
        bool Update(int id, CategoryRequest request);
        bool Delete(int id);
    }
}
