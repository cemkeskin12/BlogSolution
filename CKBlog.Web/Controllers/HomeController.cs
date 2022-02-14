using CKBlog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using CKBlog.Entity.Dtos;
using CKBlog.Service.Services.Abstract;
using CKBlog.Web.Areas.Admin.Models;
using ArticleListModel = CKBlog.Web.Areas.Admin.Models.ArticleListModel;

namespace CKBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, ICategoryService categoryService)
        {
            _logger = logger;
            _articleService = articleService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var searchResult = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            return View(new ArticleSearchViewModel
                {
                    ArticleListDto = searchResult,
                    Keyword = keyword
                });
        }
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {

            _logger.LogWarning("Şimdi buradasın");
            var articlesResult = await (categoryId == null
                ? _articleService.GetAllByPagingAsync(null, currentPage, pageSize, isAscending)
                : _articleService.GetAllByPagingAsync(categoryId.Value, currentPage, pageSize, isAscending));
            return View(articlesResult);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var value = await _articleService.ListAllArticlesByIdAsync(id);
            return View(value);
        }
    }
}
