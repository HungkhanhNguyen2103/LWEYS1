using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service? Service { get; set; }
        public string? UserName { get; set; }
        public OrderTypeEnum OrderType { get; set; }
    }

    public enum OrderTypeEnum
    {
        Booking = 0,
        InUse = 1,
        Paying = 2,
        Paid = 3,
        Cancel = 4
    }

    public static class OrderType
    {
        public static string Booking = "Đã đặt";
        public static string InUse = "Đang sử dụng";
        public static string Paying = "Đang thanh toán";
        public static string Paid = "Đã thanh toán";
        public static string Cancel = "Đã hủy";

        public static List<string> ListOrderTypes = new List<string> { Booking, InUse,Paying,Paid,Cancel};
    }


}
