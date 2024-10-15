using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.API;
using LWEYS.Common;

namespace LWEYS.Services.Order
{
    public class OrderService : IOrderService
    {
        public static WebAPICaller _api;
        public OrderService(WebAPICaller api)
        {
            _api = api;
        }
        public async Task<ReponderModel<ServiceModel>> GetAllService()
        {
            var res = new ReponderModel<ServiceModel>();
            try
            {
                string url = PathUrl.SERVICE_GETALL;
                res = await _api.Get<ReponderModel<ServiceModel>>(url);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> DeleteService(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.SERVICE_DELETE;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<ServiceModel>> GetService(int id)
        {
            var res = new ReponderModel<ServiceModel>();
            try
            {
                string url = PathUrl.SERVICE_GETDETAIL;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<ServiceModel>>(url, param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateService(ServiceModel serviceModel)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.SERVICE_UPDATE;
                res = await _api.Post<ReponderModel<string>>(url,serviceModel);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> Booking(int serviceId, DateTime bookingDate, string username)
        {
            var res = new ReponderModel<string>();
            try
            {
                var serviceOrder = new ServiceOrder
                {
                    OrderDate = bookingDate,
                    ServiceId = serviceId,
                    UserName = username,
                    OrderType = OrderTypeEnum.Booking
                };
                string url = PathUrl.SERVICE_BOOKING;
                res = await _api.Post<ReponderModel<string>>(url, serviceOrder);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<ServiceOrderModel>> GetListServiceOrder(string username)
        {
            var res = new ReponderModel<ServiceOrderModel>();
            try
            {
                string url = PathUrl.SERVICE_GETLISTSERVICE_ORDER;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                res = await _api.Get<ReponderModel<ServiceOrderModel>>(url, param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> CancelBooking(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.SERVICE_CANCEL_BOOKING;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<ReportModel>> Report()
        {
            var res = new ReponderModel<ReportModel>();
            try
            {
                string url = PathUrl.REPORT_APP;
                res = await _api.Get<ReponderModel<ReportModel>>(url);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> ChangeServiceOrderType(int id, OrderTypeEnum orderType)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.SERVICE_CHANGE_ORDERTYPE;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                param.Add("orderType", orderType.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<ServiceOrderHistoryModel>> ShowPayment(int serviceId)
        {
            var res = new ReponderModel<ServiceOrderHistoryModel>();
            try
            {
                string url = PathUrl.SERVICE_SHOW_PAYMENT;
                var param = new Dictionary<string, string>();
                param.Add("serviceId", serviceId.ToString());
                res = await _api.Get<ReponderModel<ServiceOrderHistoryModel>>(url, param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> PaymentOrder(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.SERVICE_PAYMENT_ORDER;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<string>>(url, param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> Rating(FeedbackModel feedbackModel)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.SERVICE_RATING;
                res = await _api.Post<ReponderModel<string>>(url,feedbackModel);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<FeedbackModel>> GetRating(int serviceId)
        {
            var res = new ReponderModel<FeedbackModel>();
            try
            {
                string url = PathUrl.SERVICE_GET_RATING;
                var param = new Dictionary<string, string>();
                param.Add("serviceId", serviceId.ToString());
                res = await _api.Get<ReponderModel<FeedbackModel>>(url,param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
