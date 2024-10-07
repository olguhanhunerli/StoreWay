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
    public class ProductsController: ControllerBase
    {
        private readonly IProductsServices _productsServices;

        public ProductsController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        [HttpGet("GetAllProductsAsync")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var entity = await _productsServices.GetAllProducts();
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("AddProductAsync")]
        public async Task<IActionResult> AddProductAsync(ProductDto productDto)
        {
            var entity = new Products
            {
                
                ProductName = productDto.ProductName,
                CategoryId = productDto.CategoryId,
                CreateDate = DateTime.UtcNow,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
            };
            await _productsServices.AddProductsAsync(entity);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteProductAsync")]
        public async Task<IActionResult> DeleteProductAsync([FromForm] int id)
        {
            await _productsServices.DeleteProductsAsync(id);
            return Ok();
        }

    }
}
