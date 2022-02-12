using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CKBlog.Data.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Content).IsRequired().HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Thumbnail).IsRequired().HasMaxLength(350);
            builder.Property(x => x.ViewCount).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasData
            (
                new Article
                {
                    Id = 1,
                    Title = "Asp.net Core'da temel CRUD işlemleri",
                    Content = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Cras ultricies ligula sed magna dictum porta.",
                    CategoryId = 1,
                    IsActive = true,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ViewCount = 0,
                    Thumbnail = "cem.jpg"
                },
                new Article
                {
                    Id = 2,
                    Title = "Entity Framework Nedir? ",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Nulla quis lorem ut libero malesuada feugiat. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.",
                    CategoryId = 2,
                    IsActive = true,
                    CreatedByName = "Admin",
                    ModifiedByName = "Admin",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ViewCount = 0,
                    Thumbnail = "keskin.jpg"
                }
            );

        }
    }
}
