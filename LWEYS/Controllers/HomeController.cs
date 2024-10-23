using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.Models;
using LWEYS.Services.AboutUs;
using LWEYS.Services.Order;
using LWEYS.Services.Post;
using LWEYS.Services.UserQuestion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Repositories;
using System.Diagnostics;
using System.Security.Claims;

namespace LWEYS.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private readonly IConfiguration _configuration;
        private readonly IPostService _postService;
        private readonly IAboutUsService _aboutUsService;
        private readonly IOrderService _orderService;
        private readonly IUserQuestionService _userQuestionService;
        public HomeController(ILogger<HomeController> logger, INotyfService notyf, IConfiguration configuration,
			IAboutUsService aboutUsService,
            IPostService postService,
			IOrderService orderService,
            IUserQuestionService userQuestionService)
		{
			_logger = logger;
			_notyf = notyf;
			_configuration = configuration;
			_aboutUsService = aboutUsService;
			_postService = postService;
			_orderService = orderService;
            _userQuestionService = userQuestionService;
		}

        public async Task<IActionResult> AboutUs()
        {
			var res = await _aboutUsService.Get();
			ViewBag.AboutUs = res.Data.Content;
            var result = await _postService.GetAll();
            ViewBag.ListPost = result.DataList;
            return View();
        }
        public async Task<IActionResult> ServiceDetailView(int id)
        {
			var res = await _orderService.GetService(id);
            var feedbacks = await _orderService.GetRating(id);
            ViewBag.Feedbacks = feedbacks.DataList;
            return View(res.Data);
        }

        public async Task<IActionResult> ProcessingPayment(int billId)
        {
            var res = await _orderService.ChangeServiceOrderType(billId,OrderTypeEnum.Processing);
            if (res.IsSussess) _notyf.Success(res.Message);
            else _notyf.Error(res.Message);
            return RedirectToAction("ServiceOrderHistory");
        }

        [HttpPost]
		public async Task<IActionResult> Booking(int serviceId,DateTime BookingDate)
		{
			if(User.Identity != null && !User.Identity.IsAuthenticated)
			{
                return Redirect("/Account/Login");
            }
			var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var res = await _orderService.Booking(serviceId, BookingDate, userName);
            if (res.IsSussess) _notyf.Success(res.Message);
			else
			{
                _notyf.Error(res.Message);
                return Redirect($"/Home/ServiceDetailView/{serviceId}");
            }
			return Redirect("/");

        }

        public async Task<IActionResult> CancelBooking(int id)
        {
            var res = await _orderService.CancelBooking(id);
            return Json(res.Message);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SendQuestion(UserQuestion userQuestion)
        {
            if (User.Identity != null && !User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            userQuestion.UserName = userName;
            var res = await _userQuestionService.SendQuestion(userQuestion);
            if (res.IsSussess) _notyf.Success(res.Message);
            else
            {
                _notyf.Error(res.Message);
                return RedirectToAction("UserQuestion");
            }
            return Redirect("/");

        }

        [Authorize]
        public IActionResult UserQuestion(string message = "")
		{
            ViewBag.Email = User.FindFirst(ClaimTypes.Email).Value;
            ViewBag.Message = message;
			return View();
		}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PaymentWithMomo(int id)
        {
            var result = await _orderService.PaymentWithMomo(id);
            return Json(result);
        }

        [Authorize]
        public async Task<IActionResult> PaymentStatus(int resultCode , string extraData)
        {
            var result = await _orderService.PaymentOrder(int.Parse(extraData), resultCode);
            return View(result);
        }

        public async Task<IActionResult> PostDetail(int id)
		{
			var post = await _postService.Get(id);
            var result = await _postService.GetAll();
			ViewBag.ListPost = result.DataList.Where(c => c.Id != id).ToList();
            return View(post.Data);
        }

        public async Task<IActionResult> ServiceView(ServiceType Type = 0)
		{
			var result = await _orderService.GetAllService();
			var rs = result.DataList.Where(c => c.ServiceTypeEnum == Type).ToList();
			ViewBag.ServiceType = Type;
            return View(rs);
        }
		public async Task<IActionResult> Sharing()
		{
            var result = await _postService.GetAll();
            ViewBag.ListPost = result.DataList.Where(c => !string.IsNullOrEmpty(c.Image)).ToList();
            return View();
        }

        [Authorize(Roles = Role.User)]
        public async Task<IActionResult> ServiceOrderHistory()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _orderService.GetListServiceOrder(userName);
            return View(result.DataList);

        }

        [Authorize(Roles = Role.User)]
        public async Task<IActionResult> UserQuestionListView()
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _userQuestionService.GetByUserName(userName);
            return View(result.DataList);

        }

        public async Task<IActionResult> ShowPayment(int serviceId)
        {
            var result = await _orderService.ShowPayment(serviceId);
            return Json(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PaymentItem(int id)
        {
            var result = await _orderService.PaymentOrder(id);
            return Json(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Feedback(FeedbackModel feedbackModel)
        {
            var result = await _orderService.Rating(feedbackModel);
            return Json(result.Message);
        }

        [Authorize]
        public async Task<IActionResult> Bill(int serviceId)
        {
            var billModel = new BillModel();
            var resultServiceHis = await _orderService.ShowPayment(serviceId);
            billModel.ServiceOrderHistoryModel = resultServiceHis.Data;

            billModel.Email = User.FindFirst(ClaimTypes.Email).Value;
            billModel.PhoneNumber = User.FindFirst(ClaimTypes.MobilePhone).Value;
            ViewBag.ServiceId = serviceId;
            return View(billModel);
        }

        public async Task<IActionResult> Index()
		{
            if(User.Identity.IsAuthenticated && (User.IsInRole("Admin") || User.IsInRole("Staff")))
            {
                return Redirect("/Admin");
            }
			var result = await _postService.GetAll();
			ViewBag.ListPost = result.DataList;
            return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
