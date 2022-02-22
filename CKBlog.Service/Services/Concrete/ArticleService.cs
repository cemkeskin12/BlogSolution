using CKBlog.Data.UnitOfWork;
using CKBlog.Entity.DbObjects;
using CKBlog.Entity.Dtos;
using CKBlog.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CKBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Article>> ListAllArticlesAsync()
        {
            return await _unitOfWork.Articles.GetAllAsync(null, a => a.Category);
        }

        public async Task<List<Article>> ListMostReadArticlesAsync()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => a.IsActive);
            var list = articles.OrderByDescending(x => x.ViewCount).Take(4);
            return new List<Article>(list);
        }

        public async Task<List<Article>> ListRandomArticlesAsync()
        {
            Random random = new Random();

            var articles = await _unitOfWork.Articles.GetAllAsync(a => a.IsActive);
            var list = articles.OrderBy(x => Guid.NewGuid()).Take(4);
            return new List<Article>(list);

        }

        public async Task<ArticleListDto> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = categoryId == null
                ? await _unitOfWork.Articles.GetAllAsync(a => a.IsActive, a => a.Category)
                : await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && a.IsActive,
                    a => a.Category);
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

        public async Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 5,
            bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var articles =
                    await _unitOfWork.Articles.GetAllAsync(a => a.IsActive, a => a.Category);
                var sortedArticles = isAscending
                    ? articles.OrderBy(a => a.ModifiedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                    : articles.OrderByDescending(a => a.ModifiedDate).Skip((currentPage - 1) * pageSize).Take(pageSize)
                        .ToList();
                return new ArticleListDto
                {
                    Articles = sortedArticles,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalCount = articles.Count,
                    IsAscending = isAscending
                };
            }
            var searchedArticles = await _unitOfWork.Articles.SearchAsync(new List<Expression<Func<Article, bool>>>
                {
                    (a) => a.Title.Contains(keyword),
                    (a) => a.Category.Name.Contains(keyword),
                },
                a => a.Category);
            var searchedAndSortedArticles = isAscending
                ? searchedArticles.OrderBy(a => a.ModifiedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : searchedArticles.OrderByDescending(a => a.ModifiedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDto
            {
                Articles = searchedAndSortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = searchedArticles.Count,
                IsAscending = isAscending
            };
        }

        public async Task<Article> ArticleAddAsync(Article entity, string createdByName)
        {
            entity.CreatedByName = createdByName;
            entity.ModifiedByName = createdByName;
            await _unitOfWork.Articles.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity;

        }
        public async Task<Article> GetByIdArticleAsync(int id)
        {
            return await _unitOfWork.Articles.GetByIdAsync(id);
        }

        public Article ArticleUpdate(Article entity, string modifiedByName)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedByName = modifiedByName;
            var result = _unitOfWork.Articles.Update(entity);
            _unitOfWork.Save();
            return result;
        }

        public Article ArticleDelete(Article entity)
        {
            var query = entity.IsActive;
            if (query)
            {
                entity.IsActive = false;
            }
            else
            {
                entity.IsActive = true;
            }

            var result = _unitOfWork.Articles.Update(entity);
            _unitOfWork.Save();
            return result;
        }

        public async Task<List<Article>> ListAllArticlesByIdAsync(int id)
        {
            return await _unitOfWork.Articles.GetAllAsync(x => x.Id == id, x => x.Category);
        }

        public async Task<List<Article>> GetAllArticlesByCategoryId(int id)
        {
            return await _unitOfWork.Articles.GetAllAsync(x => x.CategoryId == id, x => x.Category);

        }
    }
}
