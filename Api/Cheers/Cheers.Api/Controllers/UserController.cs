using Cheers.Core.Entities;
using Cheers.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cheers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;

        public UserController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                _authService.RegisterUser(user);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var existingUser = _authService.GetUserByEmail(loginModel.Email);
            if (existingUser == null || existingUser.Password != loginModel.Password) // יש לבצע הצפנה לסיסמאות
            {
                return Unauthorized();
            }

            var token = _authService.GenerateJwtToken(existingUser);
            return Ok(new { Token = token });
        }
    }
}
