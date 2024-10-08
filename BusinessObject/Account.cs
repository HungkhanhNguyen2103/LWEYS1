using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Account : IdentityUser
    {
        public string? FullName { get; set; }
        public int Gender { get; set; }
        public string? Address { get; set; }
    }
}
