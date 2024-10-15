using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ServiceOrderHistory
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsPayment { get; set; }
        public bool IsRating { get; set; }
        public int ServiceOrderId { get; set; }
        [ForeignKey("ServiceOrderId")]
        public ServiceOrder? ServiceOrder { get; set; }
    }
}
