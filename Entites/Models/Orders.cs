using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User Users { get; set; }
        public string shipping_city { get; set; }
        public string shipping_district { get; set; }
        public string shipping_country { get; set; }
        public string shipping_phone    { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
