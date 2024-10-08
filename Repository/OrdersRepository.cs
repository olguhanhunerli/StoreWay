using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.StoreWayDbContext;

namespace Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreWayContext _context;

        public OrdersRepository(StoreWayContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Orders entity)
        {
           _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await  _context.Orders.FindAsync(id);
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Orders>> GetAllAsync()
        {
            return await _context.Orders.Include(p => p.Users).ToListAsync();
        }

        public async Task<Orders> GetByIdAsync(int id)
        {
            var entity = await _context.Orders.Include(p => p.Users).FirstOrDefaultAsync(p => p.Id== id);
            if (entity == null)
            {
                
            }
            return entity;
        }

        public async Task UpdateAsync(Orders entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
