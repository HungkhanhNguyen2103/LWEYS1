using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.API;
using LWEYS.Common;

namespace LWEYS.Services.UserQuestion
{
    public class UserQuestionService : IUserQuestionService
    {
        public static WebAPICaller _api;
        public UserQuestionService(WebAPICaller api)
        {
            _api = api;
        }

        public async Task<ReponderModel<BusinessObject.UserQuestion>> Get()
        {
            var res = new ReponderModel<BusinessObject.UserQuestion>();
            try
            {
                string url = PathUrl.USER_QUESTION_GETALL;
                res = await _api.Get<ReponderModel<BusinessObject.UserQuestion>>(url);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }

        public async Task<ReponderModel<string>> SendQuestion(BusinessObject.UserQuestion userQuestion)
        {
            var res = new ReponderModel<string>();
            try
            {
                string url = PathUrl.USER_QUESTION_SEND;
                res = await _api.Post<ReponderModel<string>>(url, userQuestion);
            }
            catch (Exception ex)
            {
                res.Message = "Lỗi gọi api!";
            }
            return res;
        }
    }
}
