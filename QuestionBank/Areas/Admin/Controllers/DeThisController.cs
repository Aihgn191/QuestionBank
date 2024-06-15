using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionBank.Models;

namespace QuestionBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeThisController : Controller
    {
        private readonly HutechQuestionBank _context;
        //private readonly List<DeThiDetail> _deThiDetail;
        public DeThisController(HutechQuestionBank context)
        {
            _context = context;
              
        }

        // GET: Admin/DeThis
        public async Task<IActionResult> Index()
        {
            var uefquestionBankContext = _context.DeThis.Include(d => d.MaMonHocNavigation);
            return View(await uefquestionBankContext.ToListAsync());
        }

        // GET: Admin/DeThis/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deThi = await _context.DeThis
                .Include(d => d.MaMonHocNavigation)
                .FirstOrDefaultAsync(m => m.MaDeThi == id);
            if (deThi == null)
            {
                return NotFound();
            }

            var deThiDetails = new List<DeThiDetail>();

            var chiTietDeThis = await _context.ChiTietDeThis
                .Where(c => c.MaDeThi == id)
                .Include(c => c.MaCauHoiNavigation) 
                .ToListAsync();

            foreach (var i in chiTietDeThis)
            {
                if (i.MaCauHoiNavigation == null) continue; 

                var dethi = new DeThiDetail
                {
                    CauHoi = i.MaCauHoiNavigation.NoiDung
                };

                var cauTraLois = await _context.CauTraLois
                    .Where(c => c.MaCauHoi == i.MaCauHoi)
                    .ToListAsync();

                foreach (var j in cauTraLois)
                {
                    switch (j.ThuTu)
                    {
                        case 1:
                            dethi.DAA = j.NoiDung;
                            break;
                        case 2:
                            dethi.DAB = j.NoiDung;
                            break;
                        case 3:
                            dethi.DAC = j.NoiDung;
                            break;
                        case 4:
                            dethi.DAD = j.NoiDung;
                            break;
                        default:
                            break;
                    }
                }

                deThiDetails.Add(dethi);
            }
            ViewBag.monhoc = deThi.MaMonHocNavigation.TenMonHoc;
            return View(deThiDetails);
        }



        // GET: Admin/DeThis/Create
        //public IActionResult Create()
        //{
        //    ViewData["MaMonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "MaMonHoc");
        //    return View();
        //}

        //// POST: Admin/DeThis/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("MaDeThi,MaMonHoc,TenDeThi,NgayTao,DaDuyet")] DeThi deThi)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        deThi.MaDeThi = Guid.NewGuid();
        //        _context.Add(deThi);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MaMonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "MaMonHoc", deThi.MaMonHoc);
        //    return View(deThi);
        //}

        // GET: Admin/DeThis/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var deThi = await _context.DeThis.FindAsync(id);
        //    if (deThi == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["MaMonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "MaMonHoc", deThi.MaMonHoc);
        //    return View(deThi);
        //}

        // POST: Admin/DeThis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("MaDeThi,MaMonHoc,TenDeThi,NgayTao,DaDuyet")] DeThi deThi)
        //{
        //    if (id != deThi.MaDeThi)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(deThi);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DeThiExists(deThi.MaDeThi))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MaMonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "MaMonHoc", deThi.MaMonHoc);
        //    return View(deThi);
        //}

        // GET: Admin/DeThis/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deThi = await _context.DeThis
                .Include(d => d.MaMonHocNavigation)
                .FirstOrDefaultAsync(m => m.MaDeThi == id);
            if (deThi == null)
            {
                return NotFound();
            }

            return View(deThi);
        }

        // POST: Admin/DeThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ctl = _context.ChiTietDeThis.Where(p => p.MaDeThi == id).ToList();
            if (ctl.Count() > 0)
            {
                foreach (var ctlItem in ctl)
                {
                    _context.Remove(ctlItem);
                }
            }

            var deThi = await _context.DeThis.FindAsync(id);
            if (deThi != null)
            {
                _context.DeThis.Remove(deThi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeThiExists(Guid id)
        {
            return _context.DeThis.Any(e => e.MaDeThi == id);
        }
    }
}
