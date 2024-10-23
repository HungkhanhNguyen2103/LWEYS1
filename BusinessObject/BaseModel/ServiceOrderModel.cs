using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class ServiceOrderModel : ServiceModel
    {
        public int ServiceOrderId { get; set; }
        public int ServiceId { get; set; }
        public OrderTypeEnum OrderTypeEnum { get; set; }
        public string? OrderType {  get; set; }
        public string? OrderDate { get; set; }
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsRating { get; set; }
        public long Price { get; set; }
    }
}
