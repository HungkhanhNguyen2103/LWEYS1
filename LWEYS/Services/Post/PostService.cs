using BusinessObject.BaseModel;
using LWEYS.API;
using LWEYS.Common;

namespace LWEYS.Services.Post
{
    public class PostService : IPostService
    {
        public static WebAPICaller _api;
        public PostService(WebAPICaller api)
        {
            _api = api;
        }

        public async Task<ReponderModel<string>> Delete(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.POST_DELETE;
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

        public async Task<ReponderModel<BusinessObject.Post>> Get(int id)
        {
            var res = new ReponderModel<BusinessObject.Post>();
            try
            {
                string url = PathUrl.POST_GETDETAIL;
                var param = new Dictionary<string, string>();
                param.Add("id", id.ToString());
                res = await _api.Get<ReponderModel<BusinessObject.Post>>(url, param);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<PostModel>> GetAll()
        {
            var res = new ReponderModel<PostModel>();
            try
            {
                string url = PathUrl.POST_GETALL;
                res = await _api.Get<ReponderModel<PostModel>>(url);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> Update(BusinessObject.Post post)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.POST_UPDATE;
                res = await _api.Post<ReponderModel<string>>(url, post);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
