using BusinessObject.BaseModel;
using LWEYS.API;
using LWEYS.Common;

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
    }
}
