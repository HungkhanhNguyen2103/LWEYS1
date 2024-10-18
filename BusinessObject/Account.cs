using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Account : IdentityUser
    {
        [Column(TypeName = "nvarchar(100)")]
        public string? FullName { get; set; }
        public int Gender { get; set; }
        public string? Address { get; set; }
    }
}
