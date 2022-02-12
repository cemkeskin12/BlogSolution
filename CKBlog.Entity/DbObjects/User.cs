using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CKBlog.Entity.DbObjects
{
    public class User:IdentityUser<int>
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
    }
}
