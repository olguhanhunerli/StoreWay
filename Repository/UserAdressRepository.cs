using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.StoreWayDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserAdressRepository : IUserAdressRepository
    {
        private readonly StoreWayContext _context;

        public UserAdressRepository(StoreWayContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserAdress entity)
        {
            await _context.UserAdress.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.UserAdress.FindAsync(id);
            if (entity != null) { 
                _context.UserAdress.Remove(entity);
            await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserAdress>> GetAllAsync()
        {
            return await _context.UserAdress.Include(c => c.Users).ToListAsync();
        }

        public async Task<UserAdress> GetByIdAsync(int id)
        {
            var entity = await _context.UserAdress.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Bulunamadı");
            }
            return entity;
        }

        public async Task UpdateAsync(UserAdress entity)
        {
              _context.UserAdress.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
