using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CKBlog.Web.ViewComponents
{
    public class MostReadViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public MostReadViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var article = await _articleService.ListMostReadArticlesAsync();
            return View(article);
        }
    }
}
