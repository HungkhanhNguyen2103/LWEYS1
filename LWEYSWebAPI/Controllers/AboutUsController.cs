using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace LWEYSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : Controller
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        public AboutUsController(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }

        [Route("Update")]
        [HttpPost]
        public async Task<ReponderModel<string>> Update(AboutUs aboutUs)
        {
            var res = await _aboutUsRepository.Update(aboutUs);
            return res;
        }

        [Route("Get")]
        [HttpGet]
        public async Task<ReponderModel<AboutUs>> Get()
        {
            var res = await _aboutUsRepository.Get();
            return res;
        }
    }
}
