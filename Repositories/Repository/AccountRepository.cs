using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<Account> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly LWEYSDbContext LWEYSDbContext;
		private readonly IConfiguration _configuration;
		public AccountRepository(LWEYSDbContext lWEYSDbContext,
            UserManager<Account> userManager, 
            RoleManager<IdentityRole> roleManager,
			IConfiguration configuration)
        {
            LWEYSDbContext = lWEYSDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
			_configuration = configuration;
        }

        public async Task<ReponderModel<Account>> GetAll()
        {
            var response = new ReponderModel<Account>();
            var result = await _userManager.Users.ToListAsync();
            response.DataList = result;
            return response;
        }

        public async Task<ReponderModel<string>> Login(AccountModel account)
        {
            var responder = new ReponderModel<string>();
            var userExists = await _userManager.FindByNameAsync(account.UserName);
            if (userExists == null)
            {
                responder.Message = "Tài khoản không tồn tại";
                return responder;
            }
            var isCheck = await _userManager.CheckPasswordAsync(userExists, account.Password);
            if (!isCheck)
            {
                responder.Message = "Mật khẩu không chính xác";
                return responder;
            }
            var roles = await _userManager.GetRolesAsync(userExists);
            responder.Message = "Đăng nhập thành công";
            responder.IsSussess = true;
            responder.Data = await EncodeSha256(userExists, string.Join(", ", roles));
            return responder;
        }

        public async Task<ReponderModel<string>> Register(AccountModel account)
        {
            var responder = new ReponderModel<string>();
            var userExists = await _userManager.FindByNameAsync(account.UserName);
            if (userExists != null)
            {
                responder.Message = "Tài khoản đã tồn tại";
                return responder;
            }
            var user = new Account
            {
                Email = account.Email,
                UserName = account.UserName,
                Address = account.Address,
                FullName = account.FullName,
            };
            var result = await _userManager.CreateAsync(user, account.Password);
            if (!result.Succeeded)
            {
                if (result.Errors.Count() != 0) responder.Message = result.Errors.First().Description;
                else responder.Message = "Tài khoản tạo không thành công";
                return responder;
            }
            try
            {
				await _userManager.AddToRoleAsync(user, Role.User);
				responder.Message = "Tạo tài khoản thành công";
				responder.IsSussess = true;
                responder.Data = await EncodeSha256(user, Role.User);
			}
            catch (Exception ex)
            {
                responder.Message = ex.Message;

			}
			return responder;
		}

		private async Task<string> EncodeSha256(Account user, string role)
		{
			string token = string.Empty;
			var key = _configuration["Tokens:Key"];
			var issuer = _configuration["Tokens:Issuer"];
			var expires = _configuration["Tokens:Expires"];

		
			var arr = expires.Split('*');
			double seconds = 1;
			foreach (var item in arr)
			{
				seconds *= Int32.Parse(item.ToString());
			}

			List<Claim> claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
			claims.Add(new Claim(ClaimTypes.Role, role == null ? "" : role));
			claims.Add(new Claim(ClaimTypes.Name, user.FullName));

			token = TokenUtil.EncodeSha256(claims, key, issuer, seconds);

			return await Task.FromResult(token);
		}

	}
}
