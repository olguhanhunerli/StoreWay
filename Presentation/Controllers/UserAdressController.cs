using Entities.Models;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Contract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAdressController : ControllerBase
    {
        private readonly IUserAdressService _services;

        public UserAdressController(IUserAdressService services)
        {
            _services = services;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var entity = await _services.GetUserAdresses();
            return Ok(entity);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddUserAdress(CreateUserAdress userAdress)
        {
            var entity = new UserAdress
             {
               Id = userAdress.Id,
               UserId = userAdress.UserId,
               city = userAdress.city,
               country = userAdress.country,
               county = userAdress.county,
               district = userAdress.district,
               phone = userAdress.phone,
               Type = userAdress.type,
                   
            };
              await _services.AddUserAdress(entity);
              return Ok(entity);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAdress(UpdateUserAdressDto userAdress, int id)
        {
            if (id != userAdress.Id)
            {
                return BadRequest("Product ID mismatch");
            }
            try
            {
                await _services.UpdateUserAdresses(userAdress);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(userAdress);
        }
    }
}
