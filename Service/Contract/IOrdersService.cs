using Entities.Models;
using Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersDto>> GetAllOrders();
        Task<OrdersDto> GetById(int id);
        Task UpdateAsync(OrdersDto orderDto);
        Task DeleteAsync(int id);
        Task AddAsync(Orders orderDto);
    }
}
