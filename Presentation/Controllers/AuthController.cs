using Entities.Models.DTO;
using Entities.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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
                    Username = registerDto.UserName,
                    email = registerDto.Email,
                    Role = role
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {

                var response = await _service.LoginAsync(loginDto.Email, loginDto.Password);

                return Ok(new
                {
                    Token = response["Token"],
                    RefreshToken = response["RefreshToken"]
                });
            }
            catch( Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return Unauthorized(new { Message = "Giriş başarısız.", Detay = ex.Message });
            }

        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            try 
            {
                var newToken = await _service.RefreshToken(tokenDto.RefreshToken);
                return Ok(new { Token = newToken });
                
            }
            catch 
            { 

                return Unauthorized();
            }
        }
        
    }
}
