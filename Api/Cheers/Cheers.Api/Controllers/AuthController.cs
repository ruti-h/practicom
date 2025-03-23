using Cheers.Api.Models;
using Cheers.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cheers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // כאן יש לבדוק את שם המשתמש והסיסמה מול מסד הנתונים
            if (model.UserName == "admin" && model.Password == "admin123")
            {
                var token = _authService.GenerateJwtToken(model.UserName, new[] { "Admin" });
                return Ok(new { Token = token });
            }
            else if (model.UserName == "matchmaker" && model.Password == "matchmaker123")
            {
                var token = _authService.GenerateJwtToken(model.UserName, new[] { "Matchmaker" });
                return Ok(new { Token = token });
            }
            else if (model.UserName == "male" && model.Password == "male123")
            {
                var token = _authService.GenerateJwtToken(model.UserName, new[] { "Male" });
                return Ok(new { Token = token });
            }
            else if (model.UserName == "women" && model.Password == "women123")
            {
                var token = _authService.GenerateJwtToken(model.UserName, new[] { "Women" });
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

    }
}
