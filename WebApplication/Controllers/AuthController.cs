using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services.Interface;
using WebApplication.Services.Models.Auth;

namespace WebApplications.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService _authService, IUserService _userService) : ControllerBase
    {
        [Authorize]
        [HttpGet("Test")]
        public IActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authService.Login(model);
            return Ok(result);
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var result = await _authService.Logout();
            return Ok(result);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(RegisterUser param)
        {
            var result = await _userService.RegisterUser(param);
            return Ok(result);
        }
    }
}
