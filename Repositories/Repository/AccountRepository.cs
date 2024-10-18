using BusinessObject;
using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
        private EmailSender _emailSender;
        public AccountRepository(LWEYSDbContext lWEYSDbContext,
            UserManager<Account> userManager, 
            RoleManager<IdentityRole> roleManager,
			IConfiguration configuration,
            EmailSender emailSender)
        {
            LWEYSDbContext = lWEYSDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
			_configuration = configuration;
            _emailSender = emailSender;
        }

        public async Task<ReponderModel<string>> ConfirmEmail(string? token)
        {
            var response = new ReponderModel<string>();
            var key = _configuration["Tokens:Key"];
            var issuer = _configuration["Tokens:Issuer"];
            if (string.IsNullOrEmpty(token)) {
                response.Message = "Xác thực không hợp lệ";
                return response;
            }
            var claims = TokenUtil.ValidateToken(token, key, issuer);
            if (claims == null) {
                response.Message = "Xác thực không hợp lệ";
                return response;
            }
            var curUser = claims.FindFirst(ClaimTypes.NameIdentifier);
            if(curUser == null)
            {
                response.Message = "Xác thực không hợp lệ";
                return response;
            }
            var user = await _userManager.FindByNameAsync(curUser.Value);
            if (user == null)
            {
                response.Message = "Tài khoản không tồn tại";
                return response;
            }
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            response.Message = "Xác thực thành công";
            response.IsSussess = true;
            //response.Data = token;
            return response;
        }

        public async Task<ReponderModel<Account>> GetAll()
        {
            var response = new ReponderModel<Account>();
            var result = await _userManager.Users.ToListAsync();
            response.DataList = result;
            return response;
        }

        public async Task<ReponderModel<AccountModel>> GetInformation(string username)
        {
            var response = new ReponderModel<AccountModel>();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) {
                response.Message = "Tài khoản không tồn tại";
                return response;
            }
            var userInfo = new AccountModel
            {
                UserName = username,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            response.IsSussess = true;
            response.Data = userInfo;
            response.Message = "Lấy dữ liệu thành công";
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
            responder.Data = await EncodeSha256(userExists, string.Join(", ", roles),userExists.EmailConfirmed);
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
            if (!long.TryParse(account.PhoneNumber,out long phoneNumber))
            {
                responder.Message = "Số điện thoại không đúng định dạng";
                return responder;
            }

            var user = new Account
            {
                Email = account.Email,
                UserName = account.UserName,
                Address = account.Address,
                FullName = account.FullName,
                PhoneNumber = account.PhoneNumber,
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
                responder.Data = await EncodeSha256(user, Role.User,user.EmailConfirmed);


                //Send Email 
                var template = await LWEYSDbContext.TemplateEmails.FirstOrDefaultAsync(c => c.Name == "EmailConfirm");
                if(template == null)
                {
                    responder.Message = "Không có dữ liệu giao diện";
                    return responder;
                }
                template.Body = !string.IsNullOrEmpty(template.Body) ? template.Body.Replace("$${EmailConfirmLink}", _configuration["WebPage:Url"] + "/Account/ConfirmSuccess?token=" + responder.Data) : string.Empty;
                var emailModel = new EmailModel
                {
                    Body = template.Body,
                    Subject = template.Subject,
                    To = new List<string>() { account.Email }
                };
                await _emailSender.SendEmailAsync(emailModel);
                responder.Message = "Tạo tài khoản thành công";
                responder.IsSussess = true;
                return responder;
            }
            catch (Exception ex)
            {
                responder.Message = ex.Message;

			}
			return responder;
		}
        
        public async Task<ReponderModel<string>> UpdateInformation(AccountModel account)
        {
            var responder = new ReponderModel<string>();
            if (account == null)
            {
                responder.Message = "Data không hợp lệ";
                return responder;
            }
            if (!long.TryParse(account.PhoneNumber, out long phoneNumber))
            {
                responder.Message = "Số điện thoại không đúng định dạng";
                return responder;
            }
            var userExist = await _userManager.FindByNameAsync(account.UserName);
            if (userExist == null)
            {
                responder.Message = "Tài khoản không tồn tại";
                return responder;
            }
            userExist.PhoneNumber = account.PhoneNumber;
            userExist.FullName = account.FullName;
            await _userManager.UpdateAsync(userExist);

            responder.IsSussess = true;
            responder.Message = "Cập nhật thành công";
            var roles = await _userManager.GetRolesAsync(userExist);
            responder.Data = await EncodeSha256(userExist, string.Join(", ", roles), userExist.EmailConfirmed);
            return responder;
        }

        private async Task<string> EncodeSha256(Account user, string role,bool emailConfirm = true)
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
			claims.Add(new Claim("EmailConfirm", emailConfirm.ToString()));
			claims.Add(new Claim(ClaimTypes.Email, user.Email));
			claims.Add(new Claim(ClaimTypes.MobilePhone, !string.IsNullOrEmpty(user.PhoneNumber) ? user.PhoneNumber : string.Empty));

			token = TokenUtil.EncodeSha256(claims, key, issuer, seconds);

			return await Task.FromResult(token);
		}

	}
}
