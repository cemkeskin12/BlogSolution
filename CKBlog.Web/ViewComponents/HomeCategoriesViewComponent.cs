using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CKBlog.Web.ViewComponents
{
    public class HomeCategoriesViewComponent :ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomeCategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.ListAllCategoriesAsync();
            return View(categories);

        }
    }
}
