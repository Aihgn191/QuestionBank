using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionBank.Models;

namespace QuestionBank.Controllers
{
    public class SQLInjectionController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HutechQuestionBank _context;

        public SQLInjectionController(UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager, HutechQuestionBank context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Include(u => u.MaKHoaNavigation).ToListAsync();

            return View(users);
        }

        // Example of vulnerable method
        public async Task<IActionResult> Vulnerable(string userId)
        {
            // Warning: This code is vulnerable to SQL injection
            var query = $"SELECT * FROM AspNetUsers WHERE Id = '{userId}'";
            var users = await _context.Users.FromSqlRaw(query).ToListAsync();
            if (users != null){
                return View("Index", users);

            }
            return View("Index");

        }
    }
}
