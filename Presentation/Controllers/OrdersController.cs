using Entities.Models;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _services;

        public OrdersController(IOrdersService services)
        {
            _services = services;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllOrders()
        {
            var entity = await _services.GetAllOrders();
            return Ok(entity);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddOrders(OrdersDto ordersDto)
        {
            var entity = new Orders
            {
                created_at = DateTime.Now,
                Id = ordersDto.Id,
                shipping_city = ordersDto.shipping_city,
                shipping_country = ordersDto.shipping_country,
                shipping_district = ordersDto.shipping_district,
                shipping_phone = ordersDto.shipping_phone,
                status = ordersDto.status,
                UserId = ordersDto.UserId,
                
            };

            await _services.AddAsync(entity);
            return Ok(entity);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders([FromHeader] int id)
        {
            await _services.DeleteAsync(id);
            return Ok(true);
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrders(int id, OrdersDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Product ID mismatch");
            }
            try
            {
                await _services.UpdateAsync(dto);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(dto);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var entity =  await _services.GetById(id);
            return Ok(entity);  
        }
    }
}
