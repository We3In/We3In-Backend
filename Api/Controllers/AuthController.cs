using Application.Abstraction.Services;
using Application.Dtos.User;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IAuthService authService, UserManager<AppUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return BadRequest("User not found");

            var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordCheck)
                return BadRequest("Password is wrong");

            var userId = user.Id; // Kullanıcı kimliği alınır
            var token = _authService.GenerateJwtToken(userId);
            return Ok(new { Token = token });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(CreateUserDto model)
        {
            string userId = Guid.NewGuid().ToString();
            string publickey = "hello";
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = userId,
                UserName = model.UserName,
                NameSurname = model.NameSurename,
                Email = model.Email,
                PublicKey = publickey
            }, model.Password);

            if (result.Succeeded)
            {
                var token = _authService.GenerateJwtToken(userId); // Yeni kullanıcıya token oluşturulur
                return Ok(new { Token = token });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
