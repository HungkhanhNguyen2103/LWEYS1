﻿using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.API;
using LWEYS.Common;
using Newtonsoft.Json.Linq;

namespace LWEYS.Services.Account
{
    public class AccountService : IAccountService
    {
        public static WebAPICaller _api;
        //private IHttpClientFactory _factory;
        private readonly IHttpContextAccessor _context;
        public AccountService(WebAPICaller api, IHttpContextAccessor context)
        {
            _api = api;
            //_factory = factory;
            _context = context;
        }

        public async Task<ReponderModel<string>> Register(AccountModel model)
        {
            var res = new ReponderModel<string>();
            if(model == null)
            {
				res.Message = "Thông tin không hợp lệ!";
                return res;
			}
            if(model.Password != model.PasswordConfirm)
            {
                res.Message = "Mật khẩu nhập lại không khớp!";
                return res;
            }
            try
            {
                string url = PathUrl.ACCOUNT_REGISTER;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;

        }

        public async Task<ReponderModel<string>> Login(AccountModel model)
        {
            var res = new ReponderModel<string>();
            if (model == null)
            {
                res.Message = "Thông tin không hợp lệ!";
                return res;
            }
            try
            {
                string url = PathUrl.ACCOUNT_LOGIN;
                res = await _api.Post<ReponderModel<string>>(url, model);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;

        }

        public async Task<ReponderModel<BusinessObject.Account>> GetAll()
        {
            var res = new ReponderModel<BusinessObject.Account>();
            try
            {
                string url = PathUrl.ACCOUNT_GETALL;
                res = await _api.Get<ReponderModel<BusinessObject.Account>>(url);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> ConfirmEmail(string token)
        {
            var res = new ReponderModel<string>();
            try
            {
                var emailConfirm = new EmailConfirm
                {
                    Token = token
                };
                string url = PathUrl.ACCOUNT_CONFIRMEMAIL;
                res = await _api.Post<ReponderModel<string>>(url, emailConfirm);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<AccountModel>> GetInformation(string username)
        {
            var res = new ReponderModel<AccountModel>();
            try
            {
                string url = PathUrl.ACCOUNT_GET_INFO;
                var param = new Dictionary<string, string>();
                param.Add("username", username);
                res = await _api.Get<ReponderModel<AccountModel>>(url,param);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdateInformation(AccountModel account)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.ACCOUNT_UPDATE_INFO;
                res = await _api.Post<ReponderModel<string>>(url, account);

            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
