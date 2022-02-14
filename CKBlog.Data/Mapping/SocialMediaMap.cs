using CKBlog.Entity.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKBlog.Data.Mapping
{
    public class SocialMediaMap : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Link).IsRequired().HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
