using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using BusinessObject;
using LWEYS.API;
using LWEYS.Services.AboutUs;
using LWEYS.Services.Account;
using LWEYS.Services.Order;
using LWEYS.Services.Post;
using LWEYS.Services.PostCategory;
using LWEYS.Services.UserQuestion;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Linq;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

// Declare DI
builder.Services.AddSingleton<WebAPICaller, WebAPICaller>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPostCategoryService, PostCategoryService>();
builder.Services.AddScoped<IAboutUsService, AboutUsService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserQuestionService, UserQuestionService>();

// Config Auto ValidateAntiforgery Token
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddHttpClient();

//builder.Services.AddHttpClient("localhost", client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["API:Url"]);
//});

builder.Services.AddNotyf(config =>
{
	config.DurationInSeconds = 5;
	config.IsDismissable = true;
	config.Position = NotyfPosition.TopRight;
}
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Use(async (context, next) =>
{
    var path = context.Request.Path.ToString().ToLower();
    if (!path.Contains("js") && !path.Contains("img") && !path.Contains("css"))
	{
        var jwtToken = context.Request.Cookies["token"];
        if (!string.IsNullOrEmpty(jwtToken))
        {
            if (path.Contains("account") && !path.Contains("listaccount") && !path.Contains("logout") && context.User.Identity.IsAuthenticated)
            {
                context.Response.Redirect("/");
                return;
            }
            var claims = TokenUtil.ValidateToken(jwtToken, builder.Configuration["Tokens:Key"], builder.Configuration["Tokens:Issuer"]);
            if (claims != null)
            {
                var claimsIdentity = new ClaimsIdentity(
                    claims.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await context.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                if (path.Contains("logout"))
                {
                    await context.SignOutAsync();
                    context.Response.Cookies.Delete("token");
                    context.Response.Redirect("/");
                    return;
                }
                if (!path.Contains("admin") && claims.IsInRole("Admin"))
                {
                    context.Response.Redirect("/Admin");
                    return;
                }
                if(path.Contains("loginsuccess") && claims.IsInRole("User"))
                {
                    context.Response.Redirect("/");
                    return;
                }
                if(path.Contains("admin") && claims.IsInRole("User"))
                {
                    context.Response.Redirect("/");
                    return;
                }
                //if(path == "/")
                //{
                //    context.Response.Redirect("/");
                //    return;
                //}
            }

        }
        else if (path.Contains("admin") && !context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Account/Login");
            return;
        }
        else if (context.User.Identity.IsAuthenticated)
        {
            await context.SignOutAsync();
            context.Response.Redirect("/");
            return;
        }
    }
	await next(context);
});

app.UseNotyf();

app.UseCookiePolicy();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
