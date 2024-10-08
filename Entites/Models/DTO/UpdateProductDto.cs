﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        [DefaultValue ("Laptop")]
        public string ProductName { get; set; }
        [DefaultValue("Good Bilgisayar")]
        public string Description { get; set; }
        [DefaultValue("10000")]
        public decimal Price { get; set; }
        [DefaultValue("0-10000")]
        public int StockQuantity { get; set; }
        [DefaultValue("2")]
        public int CategoryId { get; set; }
        [DefaultValue("Monster")]
        public string? Brand { get; set; }
        [DefaultValue("0&1000")]
        public decimal RetailPrice { get; set; }
        [DefaultValue("0/1")]
        public int Status { get; set; }
    }

}
