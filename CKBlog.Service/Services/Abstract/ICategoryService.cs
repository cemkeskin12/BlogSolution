using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;

namespace CKBlog.Service.Services.Abstract
{
    public interface ICategoryService 
    {
        Task<List<Category>> ListAllCategoriesAsync();

        Task<Category> CategoryAddAsync(Category entity, string createdByName);

        Task<Category> GetByIdCategoryAsync(int id);

        Category CategoryUpdate(Category entity, string modifiedByName);

        Category CategoryDelete(Category entity);
    }
}
