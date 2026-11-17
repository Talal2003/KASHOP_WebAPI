using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Services
{
    public interface IAuthService
    {
        Task<(bool Success, List<string> Error)> RegisterAsync(RegisterRequest request);
        Task<(bool Success, List<string> Error, LoginResponse response)> LoginAsync(LoginRequest request);
    }
}
