using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.StoreWayDbContext;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreWayContext _context;

        public CategoryRepository(StoreWayContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category entity)
        {
           
            _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(int id)
        {
           var entity = await _context.Categories.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Aradığınız Id {id} bulunamadı.");
            }
             _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
            
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var entity =  _context.Categories.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException($"Aradığınız Id {id} bulunamadı.");
            }
            return await entity;
        }
        public async Task UpdateAsync(Category entity)
        {
           _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
