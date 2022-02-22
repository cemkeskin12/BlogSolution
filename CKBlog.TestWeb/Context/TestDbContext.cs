using CKBlog.TestWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace CKBlog.TestWeb.Context
{
    public class TestDbContext : DbContext
    {

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMapping());
        }
    }
}
