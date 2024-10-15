using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class ServiceOrderHistoryModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public string? CreateTime { get; set; }
        public int ServiceOrderId { get; set; }
    }
}
