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
        public async Task<ReponderModel<AccountViewModel>> GetAll(string role)
        {
            var rs = await _accountRepository.GetAll(role);
            return rs;
        }

        [Route("ToggleLockUser")]
        [HttpGet]
        public async Task<ReponderModel<string>> ToggleLockUser(string username,bool lockAccount)
        {
            var rs = await _accountRepository.ToggleLockUser(username,lockAccount);
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

        [Route("GrantAccessRole")]
        [HttpPost]
        public async Task<ReponderModel<string>> GrantAccessRole(AccountModel model)
        {
            var rs = await _accountRepository.GrantAccessRole(model.UserName);
            return rs;
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public async Task<ReponderModel<string>> ForgotPassword(AccountModel model)
        {
            var rs = await _accountRepository.ForgotPassword(model.Email);
            return rs;
        }

        [Route("ConfirmEmail")]
        [HttpPost]
        public async Task<ReponderModel<string>> ConfirmEmail(EmailConfirm email)
        {
            var rs = await _accountRepository.ConfirmEmail(email.Token);
            return rs;
        }

        [Route("UpdateInformation")]
        [HttpPost]
        public async Task<ReponderModel<string>> UpdateInformation(AccountModel account)
        {
            var rs = await _accountRepository.UpdateInformation(account);
            return rs;
        }

        [Route("Information")]
        [HttpGet]
        public async Task<ReponderModel<AccountModel>> Information(string username)
        {
            var rs = await _accountRepository.GetInformation(username);
            return rs;
        }
    }
}
