using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using CKBlog.Service.Services.Abstract;
using CKBlog.Service.ValidationRules;
using CKBlog.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CKBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryValidator _categoryValidator = new CategoryValidator();


        public CategoryController(UserManager<User> userManager, ICategoryService categoryService) : base(userManager)
        {
            _categoryService = categoryService;
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor,User")]
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.ListAllCategoriesAsync();
            return View(new CategoryListModel()
            {
                Categories = result,
            });
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            var results = await _categoryValidator.ValidateAsync(category);
            if (results.IsValid)
            {
                await _categoryService.CategoryAddAsync(category, LoggedInUser.UserName);
                return RedirectToAction("Index", "Category");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _categoryService.GetByIdCategoryAsync(id);
            _categoryService.CategoryDelete(value);
            return RedirectToAction("Index", "Category");
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _categoryService.GetByIdCategoryAsync(id);
            return View(new CategoryUpdateModel()
            {
                Name = value.Name,
            });
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        [HttpPost]
        public IActionResult Update(Category category)
        {
            var results = _categoryValidator.Validate(category);
            if (results.IsValid)
            {
                _categoryService.CategoryUpdate(category, LoggedInUser.UserName);
                return RedirectToAction("Index", "Category");
            }

            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }


    }
}
