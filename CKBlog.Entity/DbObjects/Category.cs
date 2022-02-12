using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Core.Entities;

namespace CKBlog.Entity.DbObjects
{
    public class Category : EntityBase, IEntity
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
