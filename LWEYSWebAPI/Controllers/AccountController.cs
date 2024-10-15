using Azure;
using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repository;

namespace LWEYSWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

		public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ReponderModel<Account>> GetAll()
        {
            var rs = await _accountRepository.GetAll();
            return rs;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ReponderModel<string>> Register(AccountModel model)
        {
            var rs = await _accountRepository.Register(model);
            return rs;
        }


        [Route("Login")]
        [HttpPost]
        public async Task<ReponderModel<string>> Login(AccountModel model)
        {
            var rs = await _accountRepository.Login(model);
            return rs;
        }
    }
}
