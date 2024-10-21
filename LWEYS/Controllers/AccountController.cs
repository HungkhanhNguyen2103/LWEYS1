﻿using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.Services.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Repositories;
using System.Security.Claims;

namespace LWEYS.Controllers
{
	public class AccountController : Controller
	{
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;
		private readonly INotyfService _notyf;
		public AccountController(IAccountService accountService, INotyfService notyf,IConfiguration configuration) 
        {
            _accountService = accountService;
			_notyf = notyf;
            _configuration = configuration;
        }

        [HttpPost]
		public async Task<IActionResult> Register(AccountModel account)
		{
            var res = await _accountService.Register(account);
			if(!res.IsSussess) _notyf.Error(res.Message);
			else
			{
                //HttpContext.Response.Cookies.Append("confirming", true.ToString());
                return RedirectToAction("EmailConfirm");
			}
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AccountInformation()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _accountService.GetInformation(userName);
            if(!result.IsSussess) _notyf.Error(result.Message);
            return View(result.Data);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateInformation(AccountModel account)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            account.UserName = userName;
            var result = await _accountService.UpdateInformation(account);
            if (!result.IsSussess)
            {
                _notyf.Error(result.Message);
                return RedirectToAction("AccountInformation");
            }
            _notyf.Success(result.Message);
            //HttpContext.Response.Cookies.Append("token", result.Data, new CookieOptions { MaxAge = TimeSpan.FromMinutes(45) });
            return RedirectToAction("Logout");
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmSuccess(string token)
        {
            var result = await _accountService.ConfirmEmail(token);
            if(!result.IsSussess)
            {
                _notyf.Error(result.Message);
                return Redirect("/");
            }
            var claims = TokenUtil.ValidateToken(token, _configuration["Tokens:Key"], _configuration["Tokens:Issuer"]);
            if (claims != null)
            {
                HttpContext.Response.Cookies.Append("token", token, new CookieOptions { MaxAge = TimeSpan.FromMinutes(45) });
                var claimsIdentity = new ClaimsIdentity(
                    claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult EmailConfirm()
        {
            return View();
        }
        public IActionResult Register()
		{
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Login(AccountModel account)
        {
            var res = await _accountService.Login(account);
            if (!res.IsSussess) _notyf.Error(res.Message);
            else
            {
                var claims = TokenUtil.ValidateToken(res.Data, _configuration["Tokens:Key"], _configuration["Tokens:Issuer"]);
                if (claims != null)
                {
                    HttpContext.Response.Cookies.Append("token", res.Data, new CookieOptions { MaxAge = TimeSpan.FromMinutes(45) });
                    var claimsIdentity = new ClaimsIdentity(
                        claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    if (claims.IsInRole("Admin") && account.ReturnUrl == "/") return Redirect("/Admin");
                    
                }
                if (string.IsNullOrEmpty(account.ReturnUrl)) account.ReturnUrl = "/";
                return Redirect(account.ReturnUrl);
            }
            return View(account);
        }

        public IActionResult Login(string ReturnUrl = "/")
		{
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
			return View(new AccountModel { ReturnUrl = ReturnUrl});
		}

        [AllowAnonymous]
        public async Task<IActionResult> VerifyToken()
        {
            var token = HttpContext.Request.Cookies["token"];
            var claims = TokenUtil.ValidateToken(token, _configuration["Tokens:Key"], _configuration["Tokens:Issuer"]);
            if (claims != null)
            {
                var claimsIdentity = new ClaimsIdentity(
                    claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                if (claims.IsInRole("Admin")) return Redirect("/Admin");
                //return Redirect("/");
            }
            return Redirect("/");
        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("token");
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
