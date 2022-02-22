using CKBlog.TestWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CKBlog.TestWeb.Services
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesAsync();
    }
}
