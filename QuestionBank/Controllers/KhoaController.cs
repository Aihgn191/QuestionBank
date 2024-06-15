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
    //[Authorize(Roles = "Admin,Teacher,Manager")]

    public class KhoaController : Controller
    {
        private readonly HutechQuestionBank _context;
        private Delete _delete;
        public KhoaController(HutechQuestionBank context, Delete delete)
        {
            _context = context;
            _delete = delete;
        }

        // GET: Khoa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Khoas.ToListAsync());
        }

        // GET: Khoa/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas
                .FirstOrDefaultAsync(m => m.MaKhoa == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // GET: Khoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhoa,TenKhoa,XoaTamKhoa")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                khoa.MaKhoa = Guid.NewGuid();
                khoa.XoaTamKhoa = false;
                _context.Add(khoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoa);
        }

        // GET: Khoa/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }
            return View(khoa);
        }

        // POST: Khoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaKhoa,TenKhoa,XoaTamKhoa")] Khoa khoa)
        {
            if (id != khoa.MaKhoa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaExists(khoa.MaKhoa))
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
            return View(khoa);
        }

        // GET: Khoa/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas
                .FirstOrDefaultAsync(m => m.MaKhoa == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // POST: Khoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _delete.DeteleKhoa(id);
            //var khoa = await _context.Khoas.FindAsync(id);
            //if (khoa != null)
            //{
            //    _context.Khoas.Remove(khoa);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaExists(Guid id)
        {
            return _context.Khoas.Any(e => e.MaKhoa == id);
        }
    }
}
