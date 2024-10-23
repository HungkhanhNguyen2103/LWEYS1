using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Feedbacks
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Message { get; set; }
        public string? UserName { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
