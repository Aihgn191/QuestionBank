using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuestionBank.Models;
using System.Drawing.Drawing2D;

namespace QuestionBank.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaTranController : Controller
    {

        private readonly HutechQuestionBank _context;
        private readonly UserManager<CustomUser> _userManager;

        public MaTranController(HutechQuestionBank context, UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
            _context = context;

        }

        List<MaTran>? GetMatrix()
        {
            var Users = _userManager.Users.FirstOrDefault(p => p.UserName == User.Identity.Name);
            string jsonmatrix = HttpContext.Session.GetString(Users.Id.ToString());
            if (jsonmatrix != null)
            {
                return JsonConvert.DeserializeObject<List<MaTran>>(jsonmatrix);
            }
            return new List<MaTran>();
        }
        void SaveCartSession(List<MaTran> ls)
        {
            var Users = _userManager.Users.FirstOrDefault(p => p.UserName == User.Identity.Name);
            string jsonmatrix = JsonConvert.SerializeObject(ls);
            HttpContext.Session.SetString(Users.Id.ToString(), jsonmatrix);

        }
        public async Task<IActionResult> Index(Guid id)
        {
            var matrix = GetMatrix();
            MonHoc? subject = _context.MonHocs.FirstOrDefault(x => x.MaMonHoc == id);
            if (subject == null)
                return BadRequest("Môn học không tồn tại");
            ViewBag.Id = subject.MaMonHoc;
            ViewBag.Monhoc = subject.TenMonHoc;
            var itemd = matrix.FirstOrDefault(p => p.MaMonHoc == id);
            if (itemd == null)
            {
                foreach (var item in _context.Phans)
                {
                    if (item.MaMonHoc == id)
                    {
                        MaTran maTran = new MaTran();
                        maTran.MaMonHoc = id;
                        maTran.TenPhan = item.TenPhan;
                        maTran.MaPhan = item.MaPhan;
                        maTran.SoCauHoi = 0;
                        maTran.Id = Guid.NewGuid();
                        matrix.Add(maTran);

                    }
                }
                SaveCartSession(matrix);
            }
            
            var findmatrix = matrix.Where(p => p.MaMonHoc == id);
            return View(findmatrix);

        }
        //    public async Task<IActionResult> Create(Guid id)
        //    {

        //        MonHoc? subject = _context.MonHocs.FirstOrDefault(x => x.MaMonHoc == id);
        //        if (subject == null)
        //            return BadRequest("Môn học không tồn tại");
        //        ViewBag.Id = subject.MaMonHoc;
        //        ViewBag.Monhoc = subject.TenMonHoc;
        //        var listphan = _context.Phans.Where(p => p.MaMonHoc == id).ToList();
        //        ViewBag.listphan = new SelectList(listphan, "MaPhan", "TenPhan");
        //        var cloList = _context.Clos
        //.Where(c => _context.CauHois
        //    .Any(ch => ch.CloId == c.CloId
        //            && ch.XoaTamCauHoi == false
        //            && ch.MaPhanNavigation.MaMonHoc == subject.MaMonHoc))
        //.ToList();

        //        ViewBag.listclo = new SelectList(cloList, "CloId", "CloName");


        //        List<SelectListItem> percentages = new List<SelectListItem>();
        //        for (int i = 10; i <= 100; i += 10)
        //        {
        //            percentages.Add(new SelectListItem { Text = $"{i}%", Value = i.ToString() });
        //        }

        //        ViewBag.listphantram = percentages;
        //        return View();
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> Create([Bind("MaMonHoc,MaPhan,Clo,PhanTram")] MaTran maTran)
        //    {
        //        var matrix = GetMatrix();
        //        var existingItem = matrix.FirstOrDefault(item => item.MaMonHoc == maTran.MaMonHoc && item.MaPhan == maTran.MaPhan && item.Clo == maTran.Clo);
        //        if (existingItem != null)
        //        {
        //            return RedirectToAction("Index", new { id = maTran.MaMonHoc });
        //        }
        //        else
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                maTran.Id = Guid.NewGuid();
        //                matrix.Add(maTran);
        //                SaveCartSession(matrix);
        //                return RedirectToAction("Index", new { id = maTran.MaMonHoc });
        //            }
        //        }
        //        return View(maTran);
        //    }
        public async Task<IActionResult> RutTrichDeThi(Guid id)
        {
            var matrix = GetMatrix();
            var subject = await _context.MonHocs.FirstOrDefaultAsync(x => x.MaMonHoc == id);
            if (subject == null)
                return BadRequest("Môn học không tồn tại");

            var maTranList = matrix.Where(p => p.MaMonHoc == id).ToList();
            List<CauHoi> Lists = new List<CauHoi>();
            foreach (var maTran in maTranList)
            {
                
                if (maTran.SoCauHoi != 0)
                {
                    var soch = maTran.SoCauHoi;
                    
                    int totalQuestions = _context.CauHois.Where(c => c.XoaTamCauHoi == false && c.MaPhan == maTran.MaPhan).Count(); // lay het cau hoi
                    if (totalQuestions < soch)
                    {
                        string d = "Không đủ câu hỏi để lấy " + maTran.TenPhan;
                        return BadRequest(d);
                    }
                    var clo1 = maTran.Clo1;
                    var clo2 = maTran.Clo2;
                    var clo3 = maTran.Clo3;
                    
                    int totalclo1 = _context.CauHois.Where(p => p.XoaTamCauHoi == false && p.MaPhan == maTran.MaPhan && p.Clo != null && p.Clo.CloId == 1).Count();
                    if (clo1 <= totalclo1)
                    {
                        var ListClo1 = _context.CauHois
                        .Where(p => p.XoaTamCauHoi == false && p.MaPhan == maTran.MaPhan && p.Clo != null && p.Clo.CloId == 1)
                        .OrderBy(q => Guid.NewGuid())
                        .Take(clo1)
                        .ToList();
                        Lists.AddRange(ListClo1);
                    }
                    else
                    {
                        string d = "Không đủ câu hỏi CLO1 trong " + maTran.TenPhan;
                        return BadRequest(d);
                        
                    }
                    
                    int totalclo2 = _context.CauHois.Where(p => p.XoaTamCauHoi == false && p.MaPhan == maTran.MaPhan && p.Clo != null && p.Clo.CloId == 1).Count();

                    if (clo2 <= totalclo2)
                    {
                        var ListClo2 = _context.CauHois
                        .Where(p => p.XoaTamCauHoi == false && p.MaPhan == maTran.MaPhan && p.Clo != null && p.Clo.CloId == 2)
                        .OrderBy(q => Guid.NewGuid())
                        .Take(clo2)
                        .ToList();
                        Lists.AddRange(ListClo2);
                    }
                    else
                    {
                        string d = "Không đủ câu hỏi CLO2 trong " + maTran.TenPhan;
                        return BadRequest(d);
                    }
                    
                    int totalclo3 = _context.CauHois.Where(p => p.XoaTamCauHoi == false && p.MaPhan == maTran.MaPhan && p.Clo != null && p.Clo.CloId == 1).Count();

                    if (clo3 <= totalclo3)
                    {
                        var ListClo3 = _context.CauHois
                        .Where(p => p.XoaTamCauHoi == false && p.MaPhan == maTran.MaPhan && p.Clo != null && p.Clo.CloId == 3)
                        .OrderBy(q => Guid.NewGuid())
                        .Take(clo3)
                        .ToList();
                        Lists.AddRange(ListClo3);
                    }
                    else
                    {
                        string d = "Không đủ câu hỏi CLO3 trong " + maTran.TenPhan;
                        return BadRequest(d);
                    }
                    if (clo1+clo2+clo3 < soch)
                    {
                        var socauhoithieu = soch - clo1 - clo2 - clo3;
                        var List2 = _context.CauHois
                            .Where(p => p.XoaTamCauHoi == false && p.MaPhan == maTran.MaPhan && !Lists.Select(q => q.MaCauHoi).Contains(p.MaCauHoi))
                            .OrderBy(q => Guid.NewGuid())
                            .Take(socauhoithieu)
                            .ToList();
                        Lists.AddRange(List2);
                    }
                }
                
            }
            var dethis = new DeThi
            {
                MaDeThi = Guid.NewGuid(),
                TenDeThi = subject.TenMonHoc,
                MaMonHoc = subject.MaMonHoc,
                NgayTao = DateTime.Now,
                ChiTietDeThis = Lists.Select((item, index) => new ChiTietDeThi
                {
                    MaPhan = item.MaPhan,
                    MaCauHoi = item.MaCauHoi,
                    ThuTu = index + 1
                }).ToList()
            };
            _context.DeThis.Add(dethis);
            await _context.SaveChangesAsync();
            SaveCartSession(matrix);

            return RedirectToAction("Index", "DeThis", new { area = "Admin" });

        }
        [HttpPost]
        public IActionResult UpdateSession(Guid maPhan, string property, string value)
        {
            var matrix = GetMatrix();
            var item = matrix.FirstOrDefault(m => m.MaPhan == maPhan);
            if (item != null)
            {
                switch (property)
                {
                    case "SoCauHoi":
                        item.SoCauHoi = int.Parse(value);
                        break;
                    case "Clo1":
                        item.Clo1 = int.Parse(value);
                        break;
                    case "Clo2":
                        item.Clo2 = int.Parse(value);
                        break;
                    case "Clo3":
                        item.Clo3 = int.Parse(value);
                        break;
                }
                SaveCartSession(matrix);
               
                return Ok();
            }
            return BadRequest();
        }
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    var matrix = GetMatrix();
        //    var maTran = matrix.FirstOrDefault(p => p.Id == id);
        //    if (maTran == null)
        //    {
        //        return NotFound();
        //    }
        //    MonHoc? subject = _context.MonHocs.FirstOrDefault(x => x.MaMonHoc == maTran.MaMonHoc);
        //    if (subject == null)
        //        return BadRequest("Môn học không tồn tại");
        //    ViewBag.Id = subject.MaMonHoc;
        //    var listphan = _context.Phans.Where(p => p.MaMonHoc == maTran.MaMonHoc).ToList();
        //    ViewBag.listphan = new SelectList(listphan, "MaPhan", "TenPhan");
        //    var cloList = _context.Clos
        //        .Where(c => _context.CauHois
        //            .Any(ch => ch.CloId == c.CloId
        //                    && ch.XoaTamCauHoi == false
        //                    && ch.MaPhanNavigation.MaMonHoc == maTran.MaMonHoc))
        //        .ToList();
        //    ViewBag.listclo = new SelectList(cloList, "CloId", "CloName");
        //    List<SelectListItem> percentages = new List<SelectListItem>();
        //    for (int i = 10; i <= 100; i += 10)
        //    {
        //        percentages.Add(new SelectListItem { Text = $"{i}%", Value = i.ToString() });
        //    }
        //    ViewBag.listphantram = percentages;
        //    return View(maTran);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(Guid id,MaTran maTran)
        //{
        //    if (id != maTran.Id)
        //    {
        //        return NotFound();
        //    }
        //    var matrix = GetMatrix();
        //    var existingItem = matrix.FirstOrDefault(p => p.Id == id);
        //    if (existingItem == null)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        existingItem.Clo = maTran.Clo;
        //        existingItem.PhanTram = maTran.PhanTram;
        //        SaveCartSession(matrix);
        //        return RedirectToAction("Index", new { id = maTran.MaMonHoc });
        //    }
        //    return View(maTran);
        //}
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var matrix = GetMatrix();
        //    var maTran = matrix.FirstOrDefault(p => p.Id == id);
        //    MonHoc? subject = _context.MonHocs.FirstOrDefault(x => x.MaMonHoc == maTran.MaMonHoc);
        //    if (subject == null)
        //        return BadRequest("Môn học không tồn tại");
        //    ViewBag.Id = subject.MaMonHoc;
        //    if (maTran == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(maTran);
        //}

        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var matrix = GetMatrix();
        //    var maTran = matrix.FirstOrDefault(p => p.Id == id);
        //    if (maTran == null)
        //    {
        //        return NotFound();
        //    }
        //    matrix.Remove(maTran);
        //    SaveCartSession(matrix);
        //    return RedirectToAction("Index", new { id = maTran.MaMonHoc });
        //}

    }
}
