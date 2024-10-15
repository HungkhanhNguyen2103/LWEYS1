using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Repositories.Repository;

namespace LWEYSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCategoryController : Controller
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        public PostCategoryController(IPostCategoryRepository postCategoryRepository)
        {
            _postCategoryRepository = postCategoryRepository;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ReponderModel<PostCategory>> GetAll()
        {
            var res = await _postCategoryRepository.GetPostCategories();
            return res;
        }

        [Route("Update")]
        [HttpPost]
        public async Task<ReponderModel<string>> Update(PostCategory postCategory)
        {
            var res = await _postCategoryRepository.UpdatePostCategory(postCategory);
            return res;
        }

        [Route("Delete")]
        [HttpGet]
        public async Task<ReponderModel<string>> Delete(int id)
        {
            var res = await _postCategoryRepository.DeletePostCategory(id);
            return res;
        }
    }
}
