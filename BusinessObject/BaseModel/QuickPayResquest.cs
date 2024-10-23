﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.BaseModel
{
    public class QuickPayResquest
    {
        public string orderInfo { get; set; }
        public string partnerCode { get; set; }
        public string redirectUrl { get; set; }
        public string ipnUrl { get; set; }
        public int amount { get; set; }
        public string orderId { get; set; }
        public string requestId { get; set; }
        public string extraData { get; set; }
        public string partnerName { get; set; }
        public string storeId { get; set; }
        public string orderGroupId { get; set; }
        public bool autoCapture { get; set; }
        public string lang { get; set; }
        public string signature { get; set; }
        public int paymentCode { get; set; }
        public int resultCode { get; set; } = -1;
        public string requestType { get; set; }
        public string responseTime { get; set; }
        public string message { get; set; } = "Lỗi hệ thống";
        public string shortLink { get; set; }

        public string payUrl { get; set; }

    }

}
