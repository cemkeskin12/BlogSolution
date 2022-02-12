using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CKBlog.Web.Areas.Admin.ViewComponents
{
    public class RoleDropdownViewComponent :ViewComponent
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleDropdownViewComponent(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
    }
}
