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

        [HttpGet("All")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var entity = await _productsServices.GetAllProducts();
            
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddProductAsync(CreateProductDto productDto)
        {
            var entity = new Products
            {
                ProductName = productDto.ProductName,
                CategoryId = productDto.CategoryId,
                CreateDate = DateTime.UtcNow,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                Brand = productDto.Brand,  
                RetailPrice = productDto.RetailPrice,
                Status = productDto.Status
            };

            await _productsServices.AddProductsAsync(entity);

            var productDtoResponse = new ProductDto
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Price = entity.Price,
                StockQuantity = entity.StockQuantity,
                Brand = entity.Brand,
                RetailPrice = entity.RetailPrice,
                Status = entity.Status,
                CreateDate = entity.CreateDate,
                CategoryName = entity.Category != null ? entity.Category.CategoryName : null
            };
            return Ok(productDtoResponse);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var dto = await _productsServices.GetProductsById(id);

            return Ok(dto);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete()]
        public async Task<IActionResult> DeleteProductAsync([FromForm] int id)
        {
            await _productsServices.DeleteProductsAsync(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto, int id)
        {
            if (id != productDto.ProductId)
            {
                return BadRequest("Product ID mismatch");
            }
            try
            {
                await _productsServices.UpdateProductAsync(productDto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(productDto);
        }

    }
}
