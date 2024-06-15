using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Data;

using Microsoft.AspNetCore.Authorization;
using QuestionBank.Models;

namespace QuestionBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Manager")]

    public class UsersController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Include(u => u.MaKHoaNavigation).ToListAsync();

            return View(users);
        }
        public async Task<IActionResult> RoleIndex()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return View(roles);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index), new { area = "Admin" });
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var roles = await _roleManager.Roles.ToListAsync();

            // Gửi danh sách vai trò và người dùng đến view
            ViewBag.UserId = id;
            ViewBag.Roles = roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Name });
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, string roleName)
        {
            // Lấy người dùng từ userId
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            if (await _userManager.IsInRoleAsync(user, roleName))
            {
                return Content("User đã có role đó rồi");
            }
            else
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
            }
            return RedirectToAction(nameof(Index), new { area = "Admin" });

        }
    }
}
