using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T request);
        void Update(T request, int id);
        void Remove(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}
