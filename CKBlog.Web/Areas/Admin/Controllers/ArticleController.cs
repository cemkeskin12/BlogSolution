using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Data.Context;
using CKBlog.Entity.DbObjects;
using CKBlog.Service.Services.Abstract;
using CKBlog.Service.ValidationRules;
using CKBlog.Web.Areas.Admin.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CKBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ArticleValidator _articleValidator = new ArticleValidator();

        public ArticleController(UserManager<User> userManager, IArticleService articleService, ICategoryService categoryService) : base(userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor,User")]

        public async Task<IActionResult> Index()
        {
            var result = await _articleService.ListAllArticlesAsync();
            return View(new ArticleListModel
            {
                Articles = result,
            });
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.ListAllCategoriesAsync();

            return View(new ArticleAddModel
            {
                Categories = categories,
            });
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]

        [HttpPost]
        public async Task<IActionResult> Add(Article article, IFormFile image)
        {
            var results = await _articleValidator.ValidateAsync(article);
            if (results.IsValid)
            {
                var imageName = DateTime.Now.ToString("dd/MM/yyyy-hh.mm.ss") + Path.GetFileName(image.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);
                await using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                article.Thumbnail = imageName;
                article.CreatedByName = LoggedInUser.UserName;
                await _articleService.ArticleAddAsync(article, article.CreatedByName);
                return RedirectToAction("Index", "Article");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var categories = await _categoryService.ListAllCategoriesAsync();

            return View(new ArticleAddModel
            {
                Categories = categories,
            });
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _articleService.GetByIdArticleAsync(id);
            _articleService.ArticleDelete(value);
            return RedirectToAction("Index", "Article");
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _articleService.GetByIdArticleAsync(id);
            var categories = await _categoryService.ListAllCategoriesAsync();
            return View(new ArticleUpdateModel()
            {
                Title = value.Title,
                Content = value.Content,
                IsActive = value.IsActive,
                Thumbnail = value.Thumbnail,
                Categories = categories,
            });
        }
        [Authorize(Roles = "SuperAdmin,Manager,Editor")]
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Article article, IFormFile image)
        {
            var results = await _articleValidator.ValidateAsync(article);
            if (results.IsValid)
            {
                var imageName = DateTime.Now.ToString("dd/MM/yyyy-hh.mm.ss") + Path.GetFileName(image.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);
                await using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                article.Thumbnail = imageName;
                article.CreatedByName = LoggedInUser.UserName;
                _articleService.ArticleUpdate(article, LoggedInUser.UserName);
                return RedirectToAction("Index", "Article");
            }

            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var categories = await _categoryService.ListAllCategoriesAsync();

            return View(new ArticleUpdateModel()
            {
                Categories = categories,
            });
        }
    }
}
