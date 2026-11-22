using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using KASHOP.BLL.Services;

namespace KASHOP.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly KASHOP.BLL.Services.IEmailService _emailService;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService,
            SignInManager<ApplicationUser> signinManager,
            IEmailService EmailService
            )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signinManager;
            _emailService = EmailService;
        }
        public async Task<(bool Success, List<string> Error)> RegisterAsync(RegisterRequest request)
        {
            var user = request.Adapt<ApplicationUser>();
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToList());

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = Uri.EscapeDataString(token);
            var link = $"https://localhost:7260/api/auth/confirm-email?userId=${user.Id}&token={encodedToken}";

            await _emailService.SendEmailAsync(user.Email, "Confirm Your Email", "" +
                "<div>" +
                $"<h2>Welcome {user.UserName}</h2>" +
                $"<p>Please confirm your email by clicking the link below</p>" +
                $"<a href='{link}'>Confirm Email</a>" +
                "</div>");



            await _userManager.CreateAsync(user, "User");

            return (true, []);
        }

        public async Task<(bool Success, List<string> Error, LoginResponse response)> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                return (false, ["invalid email or password"], null);

            var result = await _signinManager.CheckPasswordSignInAsync(user, request.Password, true);

            if(result.IsNotAllowed)
                return (false, ["Confirm your email"], null);

            if (result.IsLockedOut)
                return (false, ["Account is locked, try again later"], null);

            if (!result.Succeeded)
                return (false, ["invalid email or password"], null);

            var token = await _tokenService.GenerateJwt(user);
            var response = new LoginResponse()
            {
                Token = token
            };

            return (true, [], response);
        }

        public async Task<(bool Success, string?Error)> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return (false, "invalid confirmation link");

            if (user.EmailConfirmed)
                return (true, null);

            user.EmailConfirmed = true;

            await _userManager.UpdateAsync(user);

            var result = await _userManager.ConfirmEmailAsync(user, token);

            return result.Succeeded ? (true, null) : (false, "invalid or expired confirmation link");
        }
    }
}
