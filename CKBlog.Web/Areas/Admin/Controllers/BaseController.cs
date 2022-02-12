using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using Microsoft.AspNetCore.Identity;

namespace CKBlog.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<User> _userManager { get; }
        public BaseController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        protected User LoggedInUser => _userManager.GetUserAsync(HttpContext.User).Result;
    }
}
