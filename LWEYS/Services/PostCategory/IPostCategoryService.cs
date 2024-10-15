using BusinessObject.BaseModel;

namespace LWEYS.Services.PostCategory
{
    public interface IPostCategoryService
    {
        Task<ReponderModel<BusinessObject.PostCategory>> GetPostCategories();
        Task<ReponderModel<string>> UpdatePostCategories(BusinessObject.PostCategory postCategory);
        Task<ReponderModel<string>> DeletePostCategories(int id);
    }
}
