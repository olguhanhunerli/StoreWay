using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //Task<Category> GetCategory(int categoryId);
    }
}
