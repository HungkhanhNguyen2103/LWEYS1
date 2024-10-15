using BusinessObject.BaseModel;

namespace LWEYS.Services.Post
{
    public interface IPostService
    {
        Task<ReponderModel<PostModel>> GetAll();
        Task<ReponderModel<BusinessObject.Post>> Get(int id);
        Task<ReponderModel<string>> Update(BusinessObject.Post post);
        Task<ReponderModel<string>> Delete(int id);
    }
}
