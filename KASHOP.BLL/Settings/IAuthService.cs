using KASHOP.DAL.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Settings
{
    public interface IAuthService
    {
        Task<(bool Success, List<string> Error)> RegisterAsync(RegisterRequest request);
    }
}
