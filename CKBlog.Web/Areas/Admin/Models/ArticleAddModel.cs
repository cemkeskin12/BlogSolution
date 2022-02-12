using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using Microsoft.AspNetCore.Http;

namespace CKBlog.Web.Areas.Admin.Models
{
    public class ArticleAddModel
    {
        public string Title { get; set; }

        public string Content { get; set; }
        
        public string Thumbnail { get; set; }
        
        public int CategoryId { get; set; }
        
        public bool IsActive { get; set; }

        public IList<Category> Categories { get; set; }
    }
}
