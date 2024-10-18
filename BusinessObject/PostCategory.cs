using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class PostCategory
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string? Description { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
