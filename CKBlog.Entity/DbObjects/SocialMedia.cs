using CKBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKBlog.Entity.DbObjects
{
    public class SocialMedia : EntityBase
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string? Icon { get; set; }
    }
}
