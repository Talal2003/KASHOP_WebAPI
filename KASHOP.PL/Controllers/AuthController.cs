using KASHOP.BLL.Services;
using KASHOP.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var (success, errors) = await _authService.RegisterAsync(request);

            return success ? Ok() : BadRequest(new { errors });
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var (success, error, response) = await _authService.LoginAsync(login);

            return success ? Ok(response) : BadRequest(new { error });
        }
    }
}
