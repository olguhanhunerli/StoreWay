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
                Products = c.Products.Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Price = p.Price,
                }).ToList()
            }).ToList();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _repository.UpdateAsync(category);
        }
    }
}
