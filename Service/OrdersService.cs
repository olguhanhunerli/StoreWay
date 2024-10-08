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
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _repository;

        public OrdersService(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Orders orderDto)
        {
           await _repository.AddAsync(orderDto);
            
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            
        }

        public async Task<IEnumerable<OrdersDto>> GetAllOrders()
        {
           var entity = await _repository.GetAllAsync();
            return entity.Select(o => new OrdersDto 
            { 
                created_at = DateTime.UtcNow,
                Id = o.Id,
                shipping_city =o.shipping_city,
                shipping_country =o.shipping_country,
                shipping_district =o.shipping_district,
                shipping_phone =o.shipping_phone,
                status =o.status,
                UserId = o.UserId,
                UserName = o.Users.Username,
            });
        }

        public async Task<OrdersDto> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var dto = new OrdersDto
            {
                created_at = DateTime.UtcNow,
                Id = entity.Id,
                UserId= entity.UserId,
                shipping_city = entity.shipping_city,
                shipping_country = entity.shipping_country,
                shipping_district = entity.shipping_district,
                shipping_phone = entity.shipping_phone,
                status = entity.status,
                UserName = entity.Users.Username,

            };
            return dto; 
            
        }

        public async Task UpdateAsync(OrdersDto orderDto)
        {
            var entity =await _repository.GetByIdAsync(orderDto.Id);
            if (entity == null)
            {
                throw new ArgumentException($"Product with ID {orderDto.Id} not found.");
            }
            entity.Id = orderDto.Id;
            entity.shipping_phone = orderDto.shipping_phone;
            entity.shipping_country = orderDto.shipping_country;
            entity.status = orderDto.status;
            entity.shipping_city = orderDto.shipping_city;
            entity.created_at = DateTime.UtcNow;
            entity.shipping_district = orderDto.shipping_district;
            

            await _repository.UpdateAsync(entity);
        }
    }
}
