using BusinessObject.BaseModel;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Repositories.Repository;

namespace LWEYSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [Route("GetAllService")]
        [HttpGet]
        public async Task<ReponderModel<ServiceModel>> GetAllService()
        {
            var res = await _orderRepository.GetAllService();
            return res;
        }

        [Route("CancelBooking")]
        [HttpGet]
        public async Task<ReponderModel<string>> CancelBooking(int id)
        {
            var res = await _orderRepository.CancelBooking(id);
            return res;
        }

        [Route("UpdateService")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateService(ServiceModel serviceModel)
        {
            var res = await _orderRepository.UpdateService(serviceModel);
            return res;
        }

        [Route("Report")]
        [HttpGet]
        public async Task<ReponderModel<ReportModel>> Report()
        {
            var res = await _orderRepository.GetReport();
            return res;
        }
        [Route("ChangeServiceOrderType")]
        [HttpGet]
        public async Task<ReponderModel<string>> ChangeServiceOrderType(int id, OrderTypeEnum orderType)
        {
            var res = await _orderRepository.ChangeServiceOrderType(id,orderType);
            return res;
        }

        [Route("ShowPayment")]
        [HttpGet]
        public async Task<ReponderModel<ServiceOrderHistoryModel>> ShowPayment(int serviceId)
        {
            var res = await _orderRepository.ShowPayment(serviceId);
            return res;
        }

        [Route("GetService")]
        [HttpGet]
        public async Task<ReponderModel<ServiceModel>> GetService(int id)
        {
            var res = await _orderRepository.GetService(id);
            return res;
        }

        [Route("PaymentOrder")]
        [HttpGet]
        public async Task<ReponderModel<string>> PaymentOrder(int id)
        {
            var res = await _orderRepository.PaymentOrder(id);
            return res;
        }

        [Route("GetListServiceOrder")]
        [HttpGet]
        public async Task<ReponderModel<ServiceOrderModel>> GetListServiceOrder(string userName)
        {
            var res = await _orderRepository.GetListServiceOrderByUser(userName);
            return res;
        }

        [Route("Rating")]
        [HttpPost]
        public async Task<ReponderModel<string>> Rating(FeedbackModel feedbackModel)
        {
            var res = await _orderRepository.Rating(feedbackModel);
            return res;
        }

        [Route("GetRating")]
        [HttpGet]
        public async Task<ReponderModel<FeedbackModel>> GetRating(int serviceId)
        {
            var res = await _orderRepository.GetRating(serviceId);
            return res;
        }

        [Route("DeleteService")]
        [HttpGet]
        public async Task<ReponderModel<string>> Delete(int id)
        {
            var res = await _orderRepository.DeleteService(id);
            return res;
        }

        [Route("Booking")]
        [HttpPost]
        public async Task<ReponderModel<string>> Booking(ServiceOrder serviceOrder)
        {
            var res = await _orderRepository.Booking(serviceOrder);
            return res;
        }
    }
}
