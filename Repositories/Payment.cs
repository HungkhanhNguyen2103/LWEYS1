using BusinessObject.BaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public static class Payment
    {
        private static readonly HttpClient client = new HttpClient();

        //private static string returnUrl = "https://localhost:50618/Home/PaymentStatus";
        //private static string returnUrl = "http://103.57.222.128:8800/Home/PaymentStatus";
        private static string returnUrl = $"{Environment.GetEnvironmentVariable("WEBPAGE_URL")}/Home/PaymentStatus";
        //var env = Environment.
        public static QuickPayResquest MoMoPayment(QuickPayResquest request)
        {
            var myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();

            string accessKey = "F8BBA842ECF85";
            string secretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz";

            //var request = new QuickPayResquest();
            request.orderInfo = "pay with MoMo";
            request.partnerCode = "MOMO";
            request.redirectUrl = returnUrl;
            request.ipnUrl = returnUrl;
            //request.amount = 5000;
            request.orderId = myuuidAsString;
            request.requestId = myuuidAsString;
            request.requestType = "payWithMethod";
            //request.extraData = "";
            request.partnerName = "MoMo Payment";
            request.storeId = "LWEYS Management";
            request.orderGroupId = "";
            request.autoCapture = true;
            request.lang = "vi";

            var rawSignature = "accessKey=" + accessKey + "&amount=" + request.amount + "&extraData=" + request.extraData + "&ipnUrl=" + request.ipnUrl + "&orderId=" + request.orderId + "&orderInfo=" + request.orderInfo + "&partnerCode=" + request.partnerCode + "&redirectUrl=" + request.redirectUrl + "&requestId=" + request.requestId + "&requestType=" + request.requestType;

            request.signature = getSignature(rawSignature, secretKey);
            var httpContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var res = client.PostAsync("https://test-payment.momo.vn/v2/gateway/api/create", httpContent).Result;
            if (res.IsSuccessStatusCode)
            {
                var responseString = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<QuickPayResquest>(responseString);
                return result;
            }
            else
            {
                return new QuickPayResquest();
            }
        }

        private static string getSignature(string text, string key)
        {
            var encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
