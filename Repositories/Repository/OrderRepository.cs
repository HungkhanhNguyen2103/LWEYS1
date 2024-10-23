using Azure;
using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LWEYSDbContext LWEYSDbContext;
        private readonly UserManager<Account> _userManager;
        private readonly IConfiguration _configuration;
        public OrderRepository(LWEYSDbContext lWEYSDbContext, UserManager<Account> userManager, IConfiguration configuration)
        {
            LWEYSDbContext = lWEYSDbContext;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ReponderModel<string>> Booking(ServiceOrder serviceOrder)
        {
            var response = new ReponderModel<string>();
            if (serviceOrder == null)
            {
                response.Message = "Dữ liệu không hợp lệ";
                return response;
            }
            if(serviceOrder.OrderDate < DateTime.Now.AddMinutes(30))
            {
                response.Message = "Lịch đặt phải sau 30 phút";
                return response;
            }

            if (serviceOrder.OrderDate.Hour < 8 || serviceOrder.OrderDate.Hour > 20)
            {
                response.Message = "Ngoài thời gian hoạt động";
                return response;
            }
            await LWEYSDbContext.ServiceOrders.AddAsync(serviceOrder);
            await LWEYSDbContext.SaveChangesAsync();
            response.IsSussess = true;
            response.Message = "Đặt lịch thành công";
            return response;
        }

        public async Task<ReponderModel<string>> CancelBooking(int id)
        {
            var response = new ReponderModel<string>();
            var rs = await LWEYSDbContext.ServiceOrders.FirstOrDefaultAsync(c => c.Id == id);
            if (rs == null)
            {
                response.Message = "Data không hợp lệ";
                return response;
            }
            rs.OrderType = OrderTypeEnum.Cancel;
            await LWEYSDbContext.SaveChangesAsync();
            response.IsSussess = true;
            response.Message = "Hủy thành công";
            return response;
        }

        public async Task<ReponderModel<string>> ChangeServiceOrderType(int id, OrderTypeEnum orderType)
        {
            var message = "Thay đổi thành công";
            var response = new ReponderModel<string>();
            var rs = await LWEYSDbContext.ServiceOrders.Include(c => c.Service).FirstOrDefaultAsync(c => c.Id == id);
            if (rs == null)
            {
                response.Message = "Data không hợp lệ";
                return response;
            }
            rs.OrderType = orderType;

            if(orderType == OrderTypeEnum.Paying)
            {
                var orderDateEnd = DateTime.Now;
                //var amount = (orderDateEnd - rs.OrderDate).Hours;
                //if (amount < 1) amount = 1;
                var amount = 1;
                var item = new ServiceOrderHistory
                {
                    CreateTime = orderDateEnd,
                    ServiceOrderId = id,
                    Amount = amount,
                    Price = amount * rs.Service.Amount,
                    UserName = rs.UserName,
                };
                await LWEYSDbContext.ServiceOrderHistories.AddAsync(item);
            }

            if(orderType == OrderTypeEnum.Processing)
            {
                message = "Hóa đơn đang được xử lý";
            }

            await LWEYSDbContext.SaveChangesAsync();
            response.IsSussess = true;
            response.Message = message;
            return response;
        }

        public async Task<ReponderModel<string>> DeleteService(int id)
        {
            var response = new ReponderModel<string>();
            var rs = await LWEYSDbContext.Services.FirstOrDefaultAsync(c => c.Id == id);
            if (rs == null) 
            {
                response.Message = "Data không hợp lệ";
                return response;
            }
            LWEYSDbContext.Services.Remove(rs);
            await LWEYSDbContext.SaveChangesAsync();
            response.Message = "Xóa thành công";
            response.IsSussess = true;
            return response;
        }

        public async Task<ReponderModel<ServiceModel>> GetAllService()
        {
            var response = new ReponderModel<ServiceModel>();
            try
            {
                var rs = await LWEYSDbContext.Services.Select(c => new ServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Amount = c.Amount,
                    Description = c.Description,
                    ServicePackageEnum = c.ServicePackage,
                    ServiceTypeEnum = c.ServiceType,
                    ServicePackage = c.ServicePackage == ServicePackageEnum.BasicPackage ? ServicePackage.BasicPackage
                                     : c.ServicePackage == ServicePackageEnum.StandardPackage ? ServicePackage.StandardPackage
                                     : ServicePackage.PremiumPackage,
                    ServiceType = c.ServiceType == ServiceType.Offline ? ServiceTypeCls.Offline : ServiceTypeCls.Online,
                }).ToListAsync();
                response.DataList = rs;
                response.IsSussess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ReponderModel<ServiceOrderModel>> GetListServiceOrderByUser(string userName)
        {
            var response = new ReponderModel<ServiceOrderModel>();
            var result = new List<ServiceOrderModel>();
            var res = LWEYSDbContext.ServiceOrders.Include(c => c.Service).AsQueryable();
            if (!string.IsNullOrEmpty(userName) && userName != "*")
            {
                res = res.Where(x => x.UserName == userName);
            }
            var listResult = await res.Select( c => new ServiceOrderModel
            {
                ServiceOrderId = c.Id,
                Name = c.Service.Name,
                ServiceId = c.ServiceId,
                UserName = c.UserName,
                OrderTypeEnum = c.OrderType,
                ServicePackage = c.Service.ServicePackage == ServicePackageEnum.BasicPackage ? ServicePackage.BasicPackage
                                     : c.Service.ServicePackage == ServicePackageEnum.StandardPackage ? ServicePackage.StandardPackage
                                     : ServicePackage.PremiumPackage,
                ServiceType = c.Service.ServiceType == ServiceType.Offline ? ServiceTypeCls.Offline : ServiceTypeCls.Online,
                OrderDate = c.OrderDate.ToString("dd-MM-yyyy HH:mm"),
                FullName = LWEYSDbContext.Users.FirstOrDefault(x => x.UserName == c.UserName).FullName,
                PhoneNumber = LWEYSDbContext.Users.FirstOrDefault(x => x.UserName == c.UserName).PhoneNumber,
                OrderType = OrderType.ListOrderTypes[(int)c.OrderType],
                IsRating = LWEYSDbContext.ServiceOrderHistories.FirstOrDefault(x => x.ServiceOrderId == c.Id) == null ? false : LWEYSDbContext.ServiceOrderHistories.FirstOrDefault(x => x.ServiceOrderId == c.Id).IsRating,
                Price = LWEYSDbContext.ServiceOrderHistories.FirstOrDefault(x => x.ServiceOrderId == c.Id) == null ? 0 : LWEYSDbContext.ServiceOrderHistories.FirstOrDefault(x => x.ServiceOrderId == c.Id).Price

            }).ToListAsync();
            response.DataList = listResult;
            response.IsSussess = true;
            return response;
        }

        public async Task<ReponderModel<FeedbackModel>> GetRating(int serviceId)
        {
            var response = new ReponderModel<FeedbackModel>();
            var fbs = LWEYSDbContext.Feedbacks.AsQueryable();
            if(serviceId != -1)
            {
                fbs = fbs.Where(c => c.ServiceId == serviceId);
            }
            var result = await fbs.Select(c => new FeedbackModel
            {
                Rating = c.Rating,
                Message = c.Message,
                UserName = c.UserName,
            }).ToListAsync();

            response.DataList = result;
            response.IsSussess = true;
            return response;
        }

        public async Task<ReponderModel<ReportModel>> GetReport()
        {
            var response = new ReponderModel<ReportModel>();
            var data = new ReportModel();
            data.TotalAccount = await LWEYSDbContext.Users.CountAsync();
            data.TotalService = await LWEYSDbContext.Services.CountAsync();
            data.TotalMoney = await LWEYSDbContext.ServiceOrderHistories.Where(c => c.IsPayment).SumAsync(c => c.Price);
            data.TotalServiceBooking = await LWEYSDbContext.ServiceOrders.Where(c => c.OrderType == OrderTypeEnum.Booking).CountAsync();
            response.Data = data;
            response.IsSussess = true;
            return response;
        }

        public async Task<ReponderModel<ServiceModel>> GetService(int id)
        {
            var response = new ReponderModel<ServiceModel>();
            var service = await LWEYSDbContext.Services.Where(c => c.Id == id).Select(c => new ServiceModel
            {
                Amount = c.Amount,
                Description = c.Description,
                Id = id,
                Name = c.Name,
                ServicePackageEnum = c.ServicePackage,
                ServicePackage = c.ServicePackage == ServicePackageEnum.BasicPackage ? ServicePackage.BasicPackage
                                     : c.ServicePackage == ServicePackageEnum.StandardPackage ? ServicePackage.StandardPackage
                                     : ServicePackage.PremiumPackage,
                ServiceType = c.ServiceType == ServiceType.Offline ? ServiceTypeCls.Offline : ServiceTypeCls.Online,
                ServiceTypeEnum = c.ServiceType
            }).FirstOrDefaultAsync();
            if (service == null)
            {
                response.Message = "Data không hợp lệ";
                return response;
            }
            response.IsSussess = true;
            response.Data = service;
            return response;
        }

        public async Task<ReponderModel<string>> PaymentOrder(int id)
        {
            var response = new ReponderModel<string>();
            var rs = await LWEYSDbContext.ServiceOrderHistories.Include(c => c.ServiceOrder).FirstOrDefaultAsync(c => c.Id == id);
            if (rs == null || rs.ServiceOrder == null)
            {
                response.Message = "Data không hợp lệ";
                return response;
            }
            rs.IsPayment = true;
            rs.ServiceOrder.OrderType = OrderTypeEnum.Paid;
            await LWEYSDbContext.SaveChangesAsync();
            response.IsSussess = true;
            response.Message = "Thanh toán thành công";
            return response;
        }

        public async Task<ReponderModel<string>> PaymentWithMomo(int id)
        {
            var response = new ReponderModel<string>();
            var rs = await LWEYSDbContext.ServiceOrderHistories.Include(c => c.ServiceOrder).FirstOrDefaultAsync(c => c.Id == id);
            if (rs == null || rs.ServiceOrder == null)
            {
                response.Message = "Data không hợp lệ";
                return response;
            }

            //Momo Payment
            //var momoPaymentUrl = Payment.MoMoPayment(new QuickPayResquest
            //{
            //    amount = rs.Price,
            //    extraData = rs.Id.ToString(),
            //});
            //if(momoPaymentUrl.resultCode != 0)
            //{
            //    response.Message = momoPaymentUrl.message;
            //    return response;
            //}
            //response.Data = momoPaymentUrl.shortLink;
            //response.Message = "Chuyển hướng thanh toán";
            //QR Payment
            var apiRequest = new APIRequestQR
            {
                accountNo = _configuration["BankingSettings:AccountNumber"],
                amount = Convert.ToInt32(rs.Price),
                accountName = _configuration["BankingSettings:AccountName"],
                acqId = int.Parse(_configuration["BankingSettings:AcqId"]),
                addInfo = "Mã đơn hàng: " + rs.Id.ToString(),
            };
            var paymentUrl = Payment.QRPayment(apiRequest);

            response.Data = paymentUrl.data.qrDataURL;
            response.IsSussess = true;
            return response;
        }

        public async Task<ReponderModel<string>> Rating(FeedbackModel feedbacks)
        {
            var response = new ReponderModel<string>();
            var rs = await LWEYSDbContext.ServiceOrderHistories.Include(c => c.ServiceOrder).FirstOrDefaultAsync(c => c.ServiceOrderId == feedbacks.ServiceOrderId);
            if (rs == null || rs.ServiceOrder == null)
            {
                response.Message = "Data không hợp lệ";
                return response;
            }
            rs.IsRating = true;

            var feedback = new Feedbacks
            {
                CreateTime = DateTime.Now,
                Message = feedbacks.Message,
                Rating = feedbacks.Rating,
                ServiceId = rs.ServiceOrder.ServiceId,
                UserName = rs.UserName,
            };
            await LWEYSDbContext.Feedbacks.AddAsync(feedback);

            await LWEYSDbContext.SaveChangesAsync();
            response.Message = "Đánh giá thành công";
            response.IsSussess = true;

            return response;
        }

        public async Task<ReponderModel<ServiceOrderHistoryModel>> ShowPayment(int serviceOrderId)
        {
            var response = new ReponderModel<ServiceOrderHistoryModel>();
            var model = new ServiceOrderHistoryModel();
            model.ServiceOrderId = serviceOrderId;
            var result = await LWEYSDbContext.ServiceOrderHistories.Where(c => c.ServiceOrderId == serviceOrderId).Include(c => c.ServiceOrder).ThenInclude(x => x.Service).FirstOrDefaultAsync();
            if (result == null || result.ServiceOrder == null || result.ServiceOrder.Service == null)
            {
                response.Message = "Data không hợp lệ";
                return response;
            }
            model.ServiceType = result.ServiceOrder.Service.ServiceType == ServiceType.Offline ? ServiceTypeCls.Offline : ServiceTypeCls.Online;
            model.ServicePackage = result.ServiceOrder.Service.ServicePackage == ServicePackageEnum.BasicPackage ? ServicePackage.BasicPackage
                                     : result.ServiceOrder.Service.ServicePackage == ServicePackageEnum.StandardPackage ? ServicePackage.StandardPackage
                                     : ServicePackage.PremiumPackage;
            model.Id = result.Id;
            model.UserName = result.UserName;
            model.Price = result.Price;
            model.CreateTime = result.CreateTime.ToString("dd-MM-yyyy HH:mm");
            response.Data = model;
            response.IsSussess = true;
            return response;
        }

        public async Task<ReponderModel<string>> UpdateService(ServiceModel serviceModel)
        {
            var response = new ReponderModel<string>();
            if (serviceModel == null)
            {
                response.Message = "Dữ liệu không hợp lệ";
                return response;
            }
            if(serviceModel.Id == 0)
            {
                var service = new Service
                {
                    Amount = serviceModel.Amount,
                    Name = serviceModel.Name,
                    Description = serviceModel.Description,
                    ServicePackage = serviceModel.ServicePackageEnum,
                    ServiceType = serviceModel.ServiceTypeEnum,
                };
                await LWEYSDbContext.Services.AddAsync(service);
            }
            else
            {
                var service = await LWEYSDbContext.Services.FirstOrDefaultAsync(c => c.Id == serviceModel.Id);
                if (service == null)
                {
                    response.Message = "Data không hợp lệ";
                    return response;
                }
                service.ServicePackage = serviceModel.ServicePackageEnum;
                service.Amount = serviceModel.Amount;
                service.Name = serviceModel.Name;
                service.Description = serviceModel.Description;
                service.ServiceType = serviceModel.ServiceTypeEnum;
            }
            await LWEYSDbContext.SaveChangesAsync();
            response.IsSussess = true;
            response.Message = "Cập nhật thành công";
            return response;
        }
    }
}
