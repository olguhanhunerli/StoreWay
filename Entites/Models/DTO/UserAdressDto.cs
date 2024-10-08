using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class UserAdressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string country { get; set; }
        public string county { get; set; }
        public string phone { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; }
        public string type { get; set; }
    }
}
