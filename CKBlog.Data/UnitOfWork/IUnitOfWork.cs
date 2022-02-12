using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Data.Repositories.Abstract;

namespace CKBlog.Data.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        Task<int> SaveAsync();
        int Save();
    }
}
