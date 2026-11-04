using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Services
{
    public interface IFileService
    {
        Task<string?> UploadAsync(IFormFile file, CancellationToken cancellationToken = default);
        void Delete(string filename);
    }
}
