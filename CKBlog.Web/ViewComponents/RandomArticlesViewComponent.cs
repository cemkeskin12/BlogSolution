using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CKBlog.Web.ViewComponents
{
    public class RandomArticlesViewComponent:ViewComponent
    {
        private readonly IArticleService _articleService;

        public RandomArticlesViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var article = await _articleService.ListRandomArticlesAsync();
            return View(article);
        }
    }
}
