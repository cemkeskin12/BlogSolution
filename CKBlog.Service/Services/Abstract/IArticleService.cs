using CKBlog.Entity.DbObjects;
using CKBlog.Entity.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CKBlog.Service.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<Article>> ListAllArticlesAsync();
        Task<List<Article>> ListMostReadArticlesAsync();
        Task<List<Article>> ListRandomArticlesAsync();
        Task<List<Article>> ListAllArticlesByIdAsync(int id);
        Task<List<Article>> GetAllArticlesByCategoryId(int id);
        Task<Article> ArticleAddAsync(Article entity, string createdByName);

        Task<Article> GetByIdArticleAsync(int id);

        Article ArticleUpdate(Article entity,string modifiedByName);

        Article ArticleDelete(Article entity);

        Task<ArticleListDto> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3,
            bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5,
            bool isAscending = false);
    }
}
