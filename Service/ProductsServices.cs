using Entities.Models;
using Entities.Models.DTO;
using Repository.Contract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsRepository _repository;

        public ProductsServices(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task AddProductsAsync(Products products)
        {
            await _repository.AddAsync(products);

        }

        public async Task DeleteProductsAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
           
            var product = await _repository.GetAllAsync();
            return product.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                Brand = p.Brand,
                RetailPrice = p.RetailPrice,
                Status = p.Status,
                CreateDate = p.CreateDate,
                CategoryName = p.Category != null ? p.Category.CategoryName : null 
            }).ToList();
        }
            
        public async Task<ProductDto> GetProductsById(int id)
        {
          var product =  await _repository.GetByIdAsync(id);
            var productDto = new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Brand = product.Brand,
                RetailPrice = product.RetailPrice,
                Status = product.Status,
                CreateDate = product.CreateDate,
                CategoryName = product.Category != null ? product.Category.CategoryName : null

            };
            return productDto;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateDto)
        {
            var product = await _repository.GetByIdAsync(updateDto.ProductId);
            if (product == null)
                throw new ArgumentException($"Product with ID {updateDto.ProductId} not found.");
            product.ProductName = updateDto.ProductName;
            product.Description = updateDto.Description;
            product.Price = updateDto.Price;
            product.StockQuantity = updateDto.StockQuantity;
            product.Brand = updateDto.Brand;
            product.CategoryId = updateDto.CategoryId;
            product.Status = updateDto.Status;
            product.UpdateAt = DateTime.UtcNow;

            await _repository.UpdateAsync(product);
        }
    }
}
