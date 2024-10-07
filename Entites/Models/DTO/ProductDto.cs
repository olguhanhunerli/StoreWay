﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        
    }
}
