using CKBlog.Entity.DbObjects;
using CKBlog.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CKBlog.Data.Context;

namespace CKBlog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin,Manager")]
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly RoleManager<Role> _roleManager;

        public UserController(UserManager<User> userManager, IPasswordHasher<User> passwordHasher, RoleManager<Role> roleManager) : base(userManager)
        {
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.Users.ToListAsync();
            return View(user);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddModel userAddModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = userAddModel.UserName,
                    FirstName = userAddModel.FirstName,
                    LastName = userAddModel.LastName,
                    Email = userAddModel.Email
                };
                var result = await _userManager.CreateAsync(user, userAddModel.Password);
                if (result.Succeeded)
                {
                    var findUser = await _userManager.FindByNameAsync(userAddModel.UserName);
                    if (findUser != null)
                    {
                        await _userManager.AddToRoleAsync(findUser, userAddModel.Role);
                        return RedirectToAction("Index", "User");

                    }
                    else
                    {
                        ModelState.AddModelError("","Geçersiz Kullanıcı");
                    }
                    //be careful
                }
                else
                {
                    ModelState.AddModelError("", "Tüm Bilgileri Doldurduğunuzdan Emin Olun.");
                    return View();
                }
            }
            return View();

        }
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User");

            }
            ModelState.AddModelError("", "Silinemedi");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            UserUpdateModel model = new UserUpdateModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateModel userUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByIdAsync(userUpdateModel.Id.ToString());
                appUser.FirstName = userUpdateModel.FirstName;
                appUser.LastName = userUpdateModel.LastName;
                appUser.UserName = userUpdateModel.UserName;
                appUser.Email = userUpdateModel.Email;
                appUser.SecurityStamp = Guid.NewGuid().ToString();
                await _userManager.UpdateAsync(appUser);
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Tüm Bilgileri Doldurduğunuzdan Emin Olun.");
                return View();
            }

        }
    }
}
