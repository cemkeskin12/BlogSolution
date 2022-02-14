using CKBlog.Entity.DbObjects;
using System.Collections.Generic;

namespace CKBlog.Web.Models
{
    public class CategoryListModel
    {
        public IList<Category> Categories { get; set; }

    }
}
