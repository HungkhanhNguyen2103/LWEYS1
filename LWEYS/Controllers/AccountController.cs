using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.Services.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LWEYS.Controllers
{
	public class AccountController : Controller
	{
        private readonly IAccountService _accountService;
		private readonly INotyfService _notyf;
		public AccountController(IAccountService accountService, INotyfService notyf) 
        {
            _accountService = accountService;
			_notyf = notyf;
        }

        [HttpPost]
		public async Task<IActionResult> Register(AccountModel account)
		{
            var res = await _accountService.Register(account);
			if(!res.IsSussess) _notyf.Error(res.Message);
			else
			{
				HttpContext.Response.Cookies.Append("token", res.Data, new CookieOptions { MaxAge = TimeSpan.FromMinutes(45) });

                return Redirect("/LoginSuccess");
			}
            return View();
        }


        public IActionResult Register()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Login(AccountModel account)
        {
            var res = await _accountService.Login(account);
            if (!res.IsSussess) _notyf.Error(res.Message);
            else
            {
                HttpContext.Response.Cookies.Append("token", res.Data, new CookieOptions { MaxAge = TimeSpan.FromMinutes(45) });
                return Redirect("/LoginSuccess");
            }
            return View();
        }

        public IActionResult Login()
		{
			return View();
		}

        //[AllowAnonymous]
        //public IActionResult Logout()
        //{
        //    return Redirect("/");
        //}
    }
}
