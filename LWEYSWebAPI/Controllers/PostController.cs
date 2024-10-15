using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;
using Repositories.Repository;

namespace LWEYSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ReponderModel<PostModel>> GetAll()
        {
            var res = await _postRepository.Get();
            return res;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<ReponderModel<Post>> Get(int id)
        {
            var res = await _postRepository.Get(id);
            return res;
        }

        [Route("Update")]
        [HttpPost]
        public async Task<ReponderModel<string>> Update(Post post)
        {
            var res = await _postRepository.UpdatePost(post);
            return res;
        }

        [Route("Delete")]
        [HttpGet]
        public async Task<ReponderModel<string>> Delete(int id)
        {
            var res = await _postRepository.DeletePost(id);
            return res;
        }
    }
}
