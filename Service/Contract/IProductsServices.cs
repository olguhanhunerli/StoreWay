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
        Task<IEnumerable<Products>> GetAllProducts();
        Task AddProductsAsync(Products products);
        Task DeleteProductsAsync(int id);
        Task UpdateProductAsync(Products products);
    }
}
