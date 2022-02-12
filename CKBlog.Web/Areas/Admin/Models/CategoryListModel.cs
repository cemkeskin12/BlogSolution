using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;

namespace CKBlog.Web.Areas.Admin.Models
{
    public class CategoryListModel
    {
        public IList<Category> Categories { get; set; }

    }
}
