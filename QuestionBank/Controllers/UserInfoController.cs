using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuestionBank.Models;

namespace QuestionBank.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly IWebHostEnvironment _environment;
        public UserInfoController(UserManager<CustomUser> userManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment; 
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string FullName, string PhoneNumber, string Address, IFormFile file  )
        {
            var user = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                
                if (file != null && file.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "img/User");
                    //đổi tên sau khi upload
                    var filePath = Path.Combine(uploadsFolder, file.FileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    user.Img = file.FileName;
                }
                
                user.Address =Address;
                user.FullName = FullName;   
                user.PhoneNumber = PhoneNumber;
                await _userManager.UpdateAsync(user);               
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
