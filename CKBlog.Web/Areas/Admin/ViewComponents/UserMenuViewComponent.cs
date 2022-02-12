using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using CKBlog.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CKBlog.Web.Areas.Admin.ViewComponents
{
    public class UserMenuViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public UserMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return Content("Kullanıcı Bulunamadı");
            }
            return View(new UserViewModel
            {
                User = user,
            });

        }
    }
}
