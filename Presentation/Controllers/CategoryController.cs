using Entities.Models;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController :ControllerBase
    {
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [HttpGet("GetAllCategoriesAsync")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        { 
            var entitiy = await _services.GetAllCategoriesAsync();
            return Ok(entitiy);
        }
       // [Authorize(Roles ="Admin")]
        [HttpPost("AddCategoriesAsync")]
        public async Task<IActionResult> AddCategoriesAsync(CategoryDto categoryDto)
        {
            var dto = new Category
            {
                CategoryName = categoryDto.CategoryName,    
            };
            await _services.AddCategoryAsync(dto);
            return Ok(dto);
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromHeader] int id)
        {
            await  _services.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
