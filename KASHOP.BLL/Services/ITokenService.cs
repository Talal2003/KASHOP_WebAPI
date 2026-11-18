using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Services
{
    public interface ITokenService
    {
        Task<string> GenerateJwt(ApplicationUser user);
    }
}
