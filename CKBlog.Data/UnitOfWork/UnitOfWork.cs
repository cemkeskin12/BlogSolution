using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Data.Context;
using CKBlog.Data.Repositories.Abstract;
using CKBlog.Data.Repositories.Concrete;

namespace CKBlog.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private ArticleRepository _articleRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_dbContext);
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_dbContext);

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
