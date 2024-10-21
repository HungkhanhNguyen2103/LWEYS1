﻿using AspNetCoreHero.ToastNotification.Abstractions;
using BusinessObject;
using BusinessObject.BaseModel;
using LWEYS.Services.AboutUs;
using LWEYS.Services.Account;
using LWEYS.Services.Order;
using LWEYS.Services.Post;
using LWEYS.Services.PostCategory;
using LWEYS.Services.UserQuestion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LWEYS.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPostCategoryService _postCategoryService;
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly IAboutUsService _aboutUsService;
        private readonly IOrderService _orderService;
        private readonly IUserQuestionService _userQuestionService;
        private readonly INotyfService _notyf;
        public AdminController(IPostCategoryService postCategoryService, 
            INotyfService notyf,
            IPostService postService,
            IAboutUsService aboutUsService,
            IOrderService orderService,
            IUserQuestionService userQuestionService,
            IAccountService accountService)
        {
            _postCategoryService = postCategoryService;
            _notyf = notyf;
            _postService = postService;
            _aboutUsService = aboutUsService;
            _orderService = orderService;
            _userQuestionService = userQuestionService;
            _accountService = accountService;
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ListService()
        {
            var res = await _orderService.GetAllService();
            ViewBag.ListService = res.DataList;
            return View();
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> GetService(int id)
        {
            var res = await _orderService.GetService(id);
            return Json(res.Data);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var res = await _orderService.DeleteService(id);
            return Json(res.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(ServiceModel serviceModel)
        {
            var res = await _orderService.UpdateService(serviceModel);
            if (res.IsSussess) _notyf.Success(res.Message);
            else _notyf.Error(res.Message);
            return RedirectToAction("ListService");
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Staff}")]
        public async Task<IActionResult> ListPostCategory()
        {
            var result = await _postCategoryService.GetPostCategories();
            ViewBag.ListPostCategory = result.DataList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Post post)
        {
            var res = await _postService.Update(post);
            if (res.IsSussess) _notyf.Success(res.Message);
            else _notyf.Error(res.Message);
            return RedirectToAction("ListPost");
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Staff}")]
        public async Task<IActionResult> ListPost()
        {
            var resultPostCategory = await _postCategoryService.GetPostCategories();
            var result = await _postService.GetAll();
            ViewBag.ListPost = result.DataList;
            ViewBag.ListPostCategory = resultPostCategory.DataList;
            return View();
        }

        public async Task<IActionResult> GetPost(int id)
        {
            var result = await _postService.Get(id);
            return Json(result.Data);
        }

        public async Task<IActionResult> DeletePost(int id)
        {
            var res = await _postService.Delete(id);
            return Json(res.Message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePostCategory(PostCategory postCategory)
        {
            var res = await _postCategoryService.UpdatePostCategories(postCategory);
            if(res.IsSussess ) _notyf.Success(res.Message);
            else _notyf.Error(res.Message);
            return RedirectToAction("ListPostCategory");
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> AboutUs()
        {
            var res = await _aboutUsService.Get();
            return View(res.Data);
        }

        public async Task<IActionResult> UpdateAboutUs(AboutUs aboutUs)
        {
            var res = await _aboutUsService.Update(aboutUs);
            if (res.IsSussess) _notyf.Success(res.Message);
            else _notyf.Error(res.Message);
            return RedirectToAction("AboutUs");
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Staff}")]
        public async Task<IActionResult> DeletePostCategory(int id)
        {
            var res = await _postCategoryService.DeletePostCategories(id);
            return Json(res.Message);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Staff}")]
        public async Task<IActionResult> UserQuestionView()
        {
            var result = await _userQuestionService.Get();
            ViewBag.ListUserQuestion = result.DataList;
            return View();
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ListAccountView(string role = Role.User)
        {
            var result = await _accountService.GetAll(role);
            ViewBag.ListRoles = Role.ListRoles;
            ViewBag.ListAccount = result.DataList;
            ViewBag.SelectedRole = role;
            ViewBag.IsCustomer = role == Role.User ? true : false;
            return View();
        }

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ToggleLockUser(string username,bool lockAccount)
        {
            var result = await _accountService.ToggleLockUser(username, lockAccount);
            return Json(result.Message);
        }

        [HttpPost]

        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> GrantAccessRole(string username)
        {
            var result = await _accountService.GrantAccessRole(new AccountModel { UserName = username});
            return Json(result.Message);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Staff}")]
        public async Task<IActionResult> ListServiceOrder()
        {
            var result = await _orderService.GetListServiceOrder("*");
            ViewBag.ListServiceOrder = result.DataList;
            return View();
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Staff}")]
        [HttpPost]
        public async Task<IActionResult> FeedbackUserQuestion(UserQuestion userQuestion)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            userQuestion.AdminUserName = username;
            var result = await _userQuestionService.FeedbackUserQuestion(userQuestion);
            if (result.IsSussess) _notyf.Success(result.Message);
            else _notyf.Error(result.Message);
            return RedirectToAction("UserQuestionView");
        }

        public async Task<IActionResult> ChangeServiceOrderType(int id, OrderTypeEnum orderType)
        {
            var result = await _orderService.ChangeServiceOrderType(id,orderType);
            return Json(result.Message);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Staff}")]
        public async Task<IActionResult> ListFeedback()
        {
            var result = await _orderService.GetRating(-1);
            return View(result.DataList);
        }

        [Authorize(Roles = $"{Role.Admin},{Role.Staff}")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Staff"))
            {
                return RedirectToAction("ListPost");
            }
            var result = await _orderService.Report();
            return View(result.Data);
        }
    }
}
