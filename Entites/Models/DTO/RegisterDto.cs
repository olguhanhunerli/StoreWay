﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class RegisterDto
    {
        [DefaultValue("user_name")]
        public string UserName { get; set; }
        [DefaultValue("user@example.com")]
        public string Email { get; set; }
        [DefaultValue("@Passw0rd123")]

        public string Password { get; set; }
        [DefaultValue("Admin/Customer")]
        public string Role { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}
