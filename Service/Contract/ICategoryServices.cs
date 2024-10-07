using Entities.Models;
using Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task UpdateCategoryAsync(Category category);
    }
}
