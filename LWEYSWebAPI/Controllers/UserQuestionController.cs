using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepository;

namespace LWEYSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuestionController : Controller
    {
        private IUserQuestionRepository _userQuestionRepository;
        public UserQuestionController(IUserQuestionRepository userQuestionRepository)
        {
            _userQuestionRepository = userQuestionRepository;
        }

        [Route("SendQuestion")]
        [HttpPost]
        public async Task<ReponderModel<string>> SendQuestion(UserQuestion question)
        {
            var res = await _userQuestionRepository.SendQuestion(question);
            return res;
        }

        [Route("GetQuestions")]
        [HttpGet]
        public async Task<ReponderModel<UserQuestion>> GetQuestions()
        {
            var res = await _userQuestionRepository.Get();
            return res;
        }
    }
}
