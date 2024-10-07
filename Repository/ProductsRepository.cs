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
    public class ProductsRepository : IProductsRepository
    {
        private readonly StoreWayContext _context;

        public ProductsRepository(StoreWayContext storeWayContext)
        {
            _context = storeWayContext;
        }

        public async Task AddAsync(Products entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (id == null)
            {
                throw new ArgumentException($"Aradığınız Id {id} bulunamadı.");
            }
             _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetByIdAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if(entity == null)
                throw new ArgumentException($"Aradığınız Id {id} bulunamadı.");
            return entity;
        }

        public async Task UpdateAsync(Products entity)
        {
           _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
