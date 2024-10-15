using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class FeedbackModel
    {
        public int ServiceOrderId { get; set; }
        public int Rating { get; set; }
        public string? Message { get; set; }
        public string? UserName { get; set; }
    }
}
