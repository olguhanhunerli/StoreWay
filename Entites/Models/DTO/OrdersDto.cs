using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class OrdersDto
    {
        
        public int Id { get; set; }
        [DefaultValue("1")]
        public int UserId { get; set; }
        [DefaultValue("olguhan")]
        public string? UserName { get; set; }
        [DefaultValue("Istanbul")]
        public string shipping_city { get; set; }
        [DefaultValue("Kadıköy")]
        public string shipping_district { get; set; }
        [DefaultValue("Türkiye")]
        public string shipping_country { get; set; }
        [DefaultValue("+905304522279")]
        public string shipping_phone { get; set; }
        [DefaultValue("Processing")]
        public string status { get; set; }
        [DefaultValue("2024-10-08T10:47:38.058Z")]
        public DateTime created_at { get; set; }
        [JsonIgnore]
        public List<User>? Users { get; set; }
    }
}
