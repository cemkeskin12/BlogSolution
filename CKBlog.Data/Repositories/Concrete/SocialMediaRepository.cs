using CKBlog.Data.Context;
using CKBlog.Data.Repositories.Abstract;
using CKBlog.Entity.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKBlog.Data.Repositories.Concrete
{
    public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
