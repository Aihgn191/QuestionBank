using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionBank.Models;

namespace QuestionBank.Controllers
{
    //[Authorize(Roles = "Manager,Teacher,Admin")]

    public class PhanController : Controller
    {
        private readonly HutechQuestionBank _context;
        private Delete _delete;
        public PhanController(HutechQuestionBank context, Delete delete)
        {
            _context = context;
            _delete = delete;
        }

        // GET: Phan
        public async Task<IActionResult> Index()
        {
            var hutechQuestionBankContext = _context.Phans.Include(p => p.MaMonHocNavigation);
            return View(await hutechQuestionBankContext.ToListAsync());
        }

        // GET: Phan/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phan = await _context.Phans
                .Include(p => p.MaMonHocNavigation)
                .FirstOrDefaultAsync(m => m.MaPhan == id);
            if (phan == null)
            {
                return NotFound();
            }

            return View(phan);
        }

        // GET: Phan/Create
        public IActionResult Create()
        {
            ViewData["MaMonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "TenMonHoc");
            return View();
        }

        // POST: Phan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhan,MaMonHoc,TenPhan,NoiDung,ThuTu,SoLuongCauHoi,MaPhanCha,MaSoPhan,XoaTamPhan,LaCauHoiNhom")] Phan phan)
        {
            ModelState.Remove("MaMonHocNavigation");
            if (ModelState.IsValid)
            {
                phan.MaSoPhan = _context.Phans.Count() > 0 ? _context.Phans.Max(p=>p.MaSoPhan) + 1 : 1;
                phan.ThuTu = 100;
                phan.SoLuongCauHoi = 0;
                phan.XoaTamPhan = false;
                phan.MaPhanCha = Guid.Empty;
                phan.MaPhan = Guid.NewGuid();
                _context.Add(phan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "TenMonHoc", phan.MaMonHoc);
            return View(phan);
        }

        // GET: Phan/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phan = await _context.Phans.FindAsync(id);
            if (phan == null)
            {
                return NotFound();
            }
            ViewData["MaMonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "TenMonHoc", phan.MaMonHoc);
            return View(phan);
        }

        // POST: Phan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaPhan,MaMonHoc,TenPhan,NoiDung,ThuTu,SoLuongCauHoi,MaPhanCha,MaSoPhan,XoaTamPhan,LaCauHoiNhom")] Phan phan)
        {
            if (id != phan.MaPhan)
            {
                return NotFound();
            }
            ModelState.Remove("MaMonHocNavigation");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanExists(phan.MaPhan))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaMonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "TenMonHoc", phan.MaMonHoc);
            return View(phan);
        }

        // GET: Phan/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phan = await _context.Phans
                .Include(p => p.MaMonHocNavigation)
                .FirstOrDefaultAsync(m => m.MaPhan == id);
            if (phan == null)
            {
                return NotFound();
            }

            return View(phan);
        }

        // POST: Phan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _delete.DeletePhan(id);
            //var phan = await _context.Phans.FindAsync(id);
            //if (phan != null)
            //{
            //    _context.Phans.Remove(phan);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanExists(Guid id)
        {
            return _context.Phans.Any(e => e.MaPhan == id);
        }
    }
}
