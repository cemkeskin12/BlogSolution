using CKBlog.Service.Services.Abstract;
using CKBlog.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CKBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private IHttpContextAccessor _httpContext;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, ICategoryService categoryService, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _articleService = articleService;
            _httpContext = httpContext;
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

            //_httpContext.HttpContext.Session.SetString("session", "view");

            return View(articlesResult);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var value = await _articleService.ListAllArticlesByIdAsync(id);
            //var test = _httpContext.HttpContext.Session.GetString("session");
            return View(value);
        }
    }
}
