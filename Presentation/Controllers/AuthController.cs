using Entities.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;

        public AuthController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            string role = string.IsNullOrEmpty(registerDto.Role) ? "Customer" : registerDto.Role;
            try
            {
                await _service.RegisterAsync(registerDto.UserName, registerDto.Email, registerDto.Password, registerDto.Role);
                var response = new
                {
                    Message = "Kayıt Başarılı",
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                    Role = role
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                var token = await _service.LoginAsync(loginDto.Email, loginDto.Password);

                return Ok(new { Token = token });
            }
            catch
            {
                return Unauthorized();
            }
        }
        
    }
}
