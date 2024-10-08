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
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _repository;

        public CategoryServices(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _repository.AddAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                ParentCategoryId = c.ParentCategoryId,
                Products = c.Products.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    CategoryId = (int)p.CategoryId,  
                    CategoryName = p.Category != null ? p.Category.CategoryName : null,  // Ürünün kategori ismi
                    Brand = p.Brand,
                    RetailPrice = p.RetailPrice,
                    Status = p.Status,
                    CreateDate = p.CreateDate
                }).ToList()
            }).ToList();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _repository.UpdateAsync(category);
        }
    }
}
