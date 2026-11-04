using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Services
{
    public interface IProductService
    {
        Task<bool>CreateAsync(ProductRequest request, CancellationToken cancellationToken);
        Task<List<ProductResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
