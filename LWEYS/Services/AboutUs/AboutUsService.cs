using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.API;
using LWEYS.Common;

namespace LWEYS.Services.AboutUs
{
    public class AboutUsService : IAboutUsService
    {
        public static WebAPICaller _api;
        public AboutUsService(WebAPICaller api)
        {
            _api = api;
        }

        public async Task<ReponderModel<string>> Update(BusinessObject.AboutUs aboutUs)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.ABOUT_US;
                res = await _api.Post<ReponderModel<string>>(url, aboutUs);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<BusinessObject.AboutUs>> Get()
        {
            var res = new ReponderModel<BusinessObject.AboutUs>();
            try
            {
                string url = PathUrl.ABOUT_US_GET;
                res = await _api.Get<ReponderModel<BusinessObject.AboutUs>>(url);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
