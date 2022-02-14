using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Data.Mapping;
using CKBlog.Entity.DbObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CKBlog.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new SocialMediaMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
        }
    }
}
