using CKBlog.Entity.DbObjects;
using CKBlog.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CKBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<UserLoginModel> _logger;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<UserLoginModel> logger) : base(userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                //userLoginModel.Password = userLoginModel.Password;
                var user = await _userManager.FindByEmailAsync(userLoginModel.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginModel.Password,
                        userLoginModel.RememberMe, false);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Login Tamamlandı.");
                        return RedirectToAction("Index", "Home", new{ Area = "Admin"});

                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
        [Authorize]
        [HttpGet]
        public ViewResult AccessDenied()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

    }
}
