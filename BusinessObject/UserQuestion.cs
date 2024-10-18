using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserQuestion
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? FullName { get; set; }
        public string? Email { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Message { get; set; }
        public string? UserName { get; set; }
        public string? AdminUserName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? AdminMessage { get; set; }
    }
}
