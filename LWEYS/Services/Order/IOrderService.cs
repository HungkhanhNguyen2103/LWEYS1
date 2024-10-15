using BusinessObject;
using BusinessObject.BaseModel;

namespace LWEYS.Services.Order
{
    public interface IOrderService
    {
        Task<ReponderModel<ServiceModel>> GetAllService();
        Task<ReponderModel<ServiceModel>> GetService(int id);
        Task<ReponderModel<string>> UpdateService(ServiceModel serviceModel);
        Task<ReponderModel<string>> DeleteService(int id);
        Task<ReponderModel<string>> Booking(int serviceId, DateTime bookingDate, string username);
        Task<ReponderModel<ServiceOrderModel>> GetListServiceOrder(string username);
        Task<ReponderModel<string>> CancelBooking(int id);
        Task<ReponderModel<ReportModel>> Report();
        Task<ReponderModel<ServiceOrderHistoryModel>> ShowPayment(int serviceId);
        Task<ReponderModel<string>> PaymentOrder(int id);
        Task<ReponderModel<string>> Rating(FeedbackModel feedbackModel);
        Task<ReponderModel<FeedbackModel>> GetRating(int serviceId);
        Task<ReponderModel<string>> ChangeServiceOrderType(int id,OrderTypeEnum orderType);

    }
}
