using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Data.Context;
using CKBlog.Data.Repositories.Abstract;
using CKBlog.Entity.DbObjects;

namespace CKBlog.Data.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
