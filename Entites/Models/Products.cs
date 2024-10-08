﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string? Brand { get; set; }
        public decimal RetailPrice { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; }

    }
}
