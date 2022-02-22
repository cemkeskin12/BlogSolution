using CKBlog.TestWeb.Context;
using CKBlog.TestWeb.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CKBlog.TestWeb.Services
{
    public class ArticleService : IArticleService
    {
        private readonly TestDbContext testDbContext;
        public ArticleService(TestDbContext testDbContext)
        {
            this.testDbContext = testDbContext;
        }
                
        public async Task<List<Article>> GetArticlesAsync()
        {
            return await testDbContext.Articles.ToListAsync();
        }
    }
}
