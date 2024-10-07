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

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            
           return await _repository.GetAllAsync();
        }

        public async Task UpdateProductAsync(Products products)
        {
            await _repository.UpdateAsync(products);
        }
    }
}
