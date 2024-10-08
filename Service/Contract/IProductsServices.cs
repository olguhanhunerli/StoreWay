using Entities.Models;
using Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IProductsServices
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task AddProductsAsync(Products products);
        Task DeleteProductsAsync(int id);
        Task UpdateProductAsync(UpdateProductDto products);
        Task<ProductDto> GetProductsById(int id);
    }
}
