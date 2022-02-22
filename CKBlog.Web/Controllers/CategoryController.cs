using CKBlog.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CKBlog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        public CategoryController(ICategoryService categoryService, IArticleService articleService)
        {
            _categoryService = categoryService;
            _articleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.ListAllCategoriesAsync();
            return View(categories);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var articles = await _articleService.GetAllArticlesByCategoryId(id);
            return View(articles);
        }
    }
}
