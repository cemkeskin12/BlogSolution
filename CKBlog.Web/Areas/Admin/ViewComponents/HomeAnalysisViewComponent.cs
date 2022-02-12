using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using CKBlog.Service.Services.Abstract;
using CKBlog.Service.Services.Concrete;
using CKBlog.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CKBlog.Web.Areas.Admin.ViewComponents
{
    public class HomeAnalysisViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleController;

        public HomeAnalysisViewComponent(IArticleService articleService, ICategoryService categoryService, UserManager<User> userManager, RoleManager<Role> roleController)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
            _roleController = roleController;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.CategoryCount = _categoryService.ListAllCategoriesAsync().Result.Count;
            ViewBag.ArticleCount = _articleService.ListAllArticlesAsync().Result.Count;
            ViewBag.UserCount = _userManager.Users.ToListAsync().Result.Count;
            ViewBag.RoleCount = _roleController.Roles.ToListAsync().Result.Count;
            return View();
        }
    }
}
