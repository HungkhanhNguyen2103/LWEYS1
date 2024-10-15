using BusinessObject;
using BusinessObject.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IOrderRepository
    {
        Task<ReponderModel<ServiceModel>> GetAllService();
        Task<ReponderModel<ServiceModel>> GetService(int id);
        Task<ReponderModel<string>> UpdateService(ServiceModel serviceModel);
        Task<ReponderModel<string>> DeleteService(int id);
        Task<ReponderModel<string>> Booking(ServiceOrder serviceOrder);
        Task<ReponderModel<string>> CancelBooking(int id);
        Task<ReponderModel<ServiceOrderModel>> GetListServiceOrderByUser(string userName);
        Task<ReponderModel<ReportModel>> GetReport();
        Task<ReponderModel<string>> PaymentOrder(int id);
        Task<ReponderModel<string>> Rating(FeedbackModel feedbackModel);
        Task<ReponderModel<FeedbackModel>> GetRating(int serviceId);
        Task<ReponderModel<string>> ChangeServiceOrderType(int id, OrderTypeEnum orderType);
        Task<ReponderModel<ServiceOrderHistoryModel>> ShowPayment(int serviceId);
    }
}
