using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;

namespace CKBlog.Web.Areas.Admin.Models
{
    public class ArticleListModel
    {
        public IList<Article> Articles { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
