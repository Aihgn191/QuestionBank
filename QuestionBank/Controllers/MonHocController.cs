using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuestionBank.Models;

namespace QuestionBank.Controllers
{
    //[Authorize(Roles ="Admin,Manager,Teacher")]
    public class MonHocController : Controller
    {
        private readonly HutechQuestionBank _context;
        private Delete _delete;
        public MonHocController(HutechQuestionBank context, Delete delete)
        {
            _context = context;
            _delete = delete;
        }

        // GET: MonHoc
        public async Task<IActionResult> Index()
        {
            var hutechQuestionBankContext = _context.MonHocs.Include(m => m.MaKhoaNavigation);
            return View(await hutechQuestionBankContext.ToListAsync());
        }

        // GET: MonHoc/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .Include(m => m.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.MaMonHoc == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // GET: MonHoc/Create
        public IActionResult Create()
        {
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "TenKhoa");
            return View();
        }

        // POST: MonHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMonHoc,MaKhoa,MaSoMonHoc,TenMonHoc,XoaTamMonHoc")] MonHoc monHoc)
        {
            ModelState.Remove("MaKhoaNavigation");
            if (ModelState.IsValid)
            {
                //monHoc.MaSoMonHoc = _context.MonHocs.Count() > 0 ? _context.MonHocs.Max(p=>p.MaSoMonHoc) + 1 : "1";
                monHoc.MaMonHoc = Guid.NewGuid();
                monHoc.XoaTamMonHoc = false;
                _context.Add(monHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "TenKhoa", monHoc.MaKhoa);
            return View(monHoc);
        }

        // GET: MonHoc/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "TenKhoa", monHoc.MaKhoa);
            return View(monHoc);
        }

        // POST: MonHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaMonHoc,MaKhoa,MaSoMonHoc,TenMonHoc,XoaTamMonHoc")] MonHoc monHoc)
        {
            if (id != monHoc.MaMonHoc)
            {
                return NotFound();
            }
            ModelState.Remove("MaKhoaNavigation");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonHocExists(monHoc.MaMonHoc))
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
            ViewData["MaKhoa"] = new SelectList(_context.Khoas, "MaKhoa", "TenKhoa", monHoc.MaKhoa);
            return View(monHoc);
        }

        // GET: MonHoc/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .Include(m => m.MaKhoaNavigation)
                .FirstOrDefaultAsync(m => m.MaMonHoc == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // POST: MonHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _delete.DeleteMH(id);
            //var monHoc = await _context.MonHocs.FindAsync(id);
            //if (monHoc != null)
            //{
            //    _context.MonHocs.Remove(monHoc);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonHocExists(Guid id)
        {
            return _context.MonHocs.Any(e => e.MaMonHoc == id);
        }
    }
}
