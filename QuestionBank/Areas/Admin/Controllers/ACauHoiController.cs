using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using QuestionBank.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjectCS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager,Admin")]
    public class ACauHoiController : Controller
    {
        private readonly HutechQuestionBank _context;
        private readonly UserManager<CustomUser> _userManager;
        public ACauHoiController(HutechQuestionBank context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/ACauHoi
        public async Task<IActionResult> Index(string query, int pageNumber = 1)
        {
            //var hutechQuestionBankContext = _context.CauHois.Include(c => c.MaPhanNavigation).Include(c => c.MaPhanNavigation.MaMonHocNavigation);
            //return View(await hutechQuestionBankContext.ToListAsync());
            var Users = _userManager.Users.FirstOrDefault(p => p.UserName == User.Identity.Name);
            int pageSize = 7;
            IQueryable<CauHoi> productsQuery = _context.CauHois.Include(p => p.MaPhanNavigation.MaMonHocNavigation.MaKhoaNavigation).Where(p => p.XoaTamCauHoi == true).Where(p => p.MaPhanNavigation.MaMonHocNavigation.MaKhoaNavigation.MaKhoa == Users.KhoaID);

            if (!string.IsNullOrEmpty(query))
            {
                productsQuery = productsQuery.Where(p => p.NoiDung.Contains(query) || p.XoaTamCauHoi.ToString() == query || p.MaPhanNavigation.MaMonHocNavigation.TenMonHoc.Contains(query));
            }

            var paginatedProducts = await PaginatedList<CauHoi>.CreateAsync(productsQuery, pageNumber, pageSize);

            // Pass the query string to the view so it's maintained during pagination
            ViewData["Query"] = query;

            return View(paginatedProducts);

        }
        public async Task<IActionResult> AcceptCH(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cauHoi = await _context.CauHois.FindAsync(id);

            if (cauHoi == null)
            {
                return NotFound();
            }

            cauHoi.XoaTamCauHoi = false;
            _context.Update(cauHoi);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { area = "Admin" }); // Chuyển hướng đến trang Index sau khi cập nhật thành công
        }
        public async Task<IActionResult> DenyCH(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cauHoi = await _context.CauHois.FindAsync(id);

            if (cauHoi == null)
            {
                return NotFound();
            }

            cauHoi.XoaTamCauHoi = null;
            _context.Update(cauHoi);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { area = "Admin" }); // Chuyển hướng đến trang Index sau khi cập nhật thành công
        }
    }
}
