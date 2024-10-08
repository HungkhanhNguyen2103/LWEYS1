using BusinessObject.BaseModel;
using Microsoft.AspNetCore.Mvc;

namespace LWEYS.Controllers
{
	public class AccountController : Controller
	{
		[HttpPost]
		public IActionResult Register(AccountModel account)
		{
            return View();
        }


        public IActionResult Register()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
