using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class UpdateUserAdressDto
    {
       
        public int Id { get; set; }
        [DefaultValue("1")]
        public int UserId { get; set; }
        [DefaultValue("Istanbul")]
        public string city { get; set; }
        [DefaultValue("Kadıköy")]
        public string district { get; set; }
        [DefaultValue("Türkiye")]
        public string country { get; set; }
        [DefaultValue("Türkiye")]
        public string county { get; set; }
        [DefaultValue("05304522279")]
        public string phone { get; set; }
        [DefaultValue("Shipping/Invoice")]
        public string type { get; set; }
    }
}
