using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.API;
using LWEYS.Common;

namespace LWEYS.Services.PostCategory
{
    public class PostCategoryService : IPostCategoryService
    {
        public static WebAPICaller _api;
        public PostCategoryService(WebAPICaller api) 
        { 
            _api = api;
        }

        public async Task<ReponderModel<string>> DeletePostCategories(int id)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.POSTCATEGORY_DELETE;
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

        public async Task<ReponderModel<BusinessObject.PostCategory>> GetPostCategories()
        {
            var res = new ReponderModel<BusinessObject.PostCategory>();
            try
            {
                string url = PathUrl.POSTCATEGORY_GETALL;
                res = await _api.Get<ReponderModel<BusinessObject.PostCategory>>(url);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> UpdatePostCategories(BusinessObject.PostCategory postCategory)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.POSTCATEGORY_UPDATE;
                res = await _api.Post<ReponderModel<string>>(url,postCategory);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
