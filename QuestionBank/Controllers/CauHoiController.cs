using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestionBank.Models;
using Xceed.Words.NET;

namespace QuestionBank.Controllers
{
    //[Authorize(Roles = "Teacher,Admin,Manager")]
    public class CauHoiController : Controller
    {
        private readonly HutechQuestionBank _context;
        private Delete _delete;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly IWebHostEnvironment _environment;
        private static List<CauHoi> cauhoiss = new List<CauHoi>();
        public CauHoiController(HutechQuestionBank context, Delete delete, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, IWebHostEnvironment environment)
        {
            _context = context;
            _delete = delete;
            _userManager = userManager;
            _signInManager = signInManager;
            _environment = environment;
        }

        // GET: CauHoi
        public async Task<IActionResult> Index()
        {
            var Users = _userManager.Users.FirstOrDefault(p => p.UserName == User.Identity.Name);
            var hutechQuestionBankContext = _context.CauHois.Include(c => c.MaPhanNavigation.MaMonHocNavigation.MaKhoaNavigation).Where(p => p.MaPhanNavigation.MaMonHocNavigation.MaKhoaNavigation.MaKhoa == Users.KhoaID);
            return View(await hutechQuestionBankContext.ToListAsync());
        }

        // GET: CauHoi/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cauHoi = await _context.CauHois
                .Include(c => c.MaPhanNavigation.MaMonHocNavigation)
                .FirstOrDefaultAsync(m => m.MaCauHoi == id);
            if (cauHoi == null)
            {
                return NotFound();
            }
            ViewBag.CauTraLoi = _context.CauTraLois.Where(p => p.MaCauHoi == id).ToList();
            return View(cauHoi);
        }

        // GET: CauHoi/Create
        public async Task<IActionResult> Create()
        {
            var Users = _userManager.Users.FirstOrDefault(p => p.UserName == User.Identity.Name);

            var phansByMonHoc = _context.Phans.Include(p => p.MaMonHocNavigation.MaKhoaNavigation).OrderBy(p => p.MaMonHocNavigation.TenMonHoc).Where(p => p.MaMonHocNavigation.MaKhoaNavigation.MaKhoa == Users.KhoaID).ToList();

            var groupedPhans = phansByMonHoc.GroupBy(p => p.MaMonHocNavigation.TenMonHoc)
                                            .Select(g => new
                                            {
                                                GroupName = g.Key,
                                                Items = g.Select(p => new SelectListItem
                                                {
                                                    Value = p.MaPhan.ToString(),
                                                    Text = p.TenPhan
                                                }).ToList()
                                            }).ToList();

            List<SelectListItem> maPhanList = new List<SelectListItem>();
            foreach (var group in groupedPhans)
            {
                maPhanList.Add(new SelectListItem { Text = group.GroupName, Disabled = true });
                foreach (var item in group.Items)
                {
                    maPhanList.Add(item);
                }
            }

            ViewData["MaPhan"] = maPhanList;
            var clos = _context.Clos.ToList(); // Lấy danh sách các đối tượng từ _context.Clos

            // Tạo một danh sách mới bằng cách thêm một mục mới vào đầu tiên
            clos.Insert(0, new Clo { CloId = 0, CloName = "Chưa Chọn CLO" });

            // Tạo SelectList từ danh sách đã được cập nhật
            ViewBag.Clos = new SelectList(clos, "CloId", "CloName");
            ViewData["MonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "TenMonHoc");
            return View();
        }

        // POST: CauHoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CauHoi cauHoi, string DAA, string DAB, string DAC, string DAD, string[] dapAnDung)
        {
            ModelState.Remove("MaPhanNavigation");
            if (ModelState.IsValid)
            {
                
                cauHoi.MaSoCauHoi = _context.CauHois.Count() > 0 ? _context.CauHois.Max(p => p.MaSoCauHoi) + 1 : 1;
                cauHoi.CapDo = 0;
                if( cauHoi.CloId == 0) {
                    cauHoi.CloId = null;
                }
                cauHoi.DoPhanCachCauHoi = 0;
                cauHoi.SoCauHoiCon = 0;
                cauHoi.MaCauHoiCha = Guid.Empty;
                cauHoi.XoaTamCauHoi = true;
                cauHoi.SoLanDuocThi = 0;
                cauHoi.SoLanDung = 0;
                cauHoi.NgayTao = DateTime.Now;
                cauHoi.NgaySua = DateTime.Now;
                cauHoi.MaCauHoi = Guid.NewGuid();
                _context.Add(cauHoi);
                int thuTu = 1;
                var dapAns = new Dictionary<string, string>
                {
                    { "DAA", DAA },
                    { "DAB", DAB },
                    { "DAC", DAC },
                    { "DAD", DAD }
                };
                foreach (var dapAn in dapAns)
                {
                    var cauTraLoi = new CauTraLoi
                    {
                        MaCauTraLoi = Guid.NewGuid(),
                        MaCauHoi = cauHoi.MaCauHoi,
                        NoiDung = dapAn.Value,
                        ThuTu = thuTu++,
                        LaDapAn = dapAnDung != null && dapAnDung.Contains(dapAn.Key)
                    };
                    _context.Add(cauTraLoi);
                }


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaPhan"] = new SelectList(_context.Phans, "MaPhan", "TenPhan", cauHoi.MaPhan);
            return View(cauHoi);
        }

        // GET: CauHoi/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
            ViewData["MaPhan"] = new SelectList(_context.Phans, "MaPhan", "TenPhan", cauHoi.MaPhan);
            ViewBag.Clos = new SelectList(_context.Clos, "CloId", "CloName", cauHoi.CloId);
            return View(cauHoi);
        }

        // POST: CauHoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CauHoi cauHoi, string DAA, string DAB, string DAC, string DAD, string[] dapAnDung)
        {
            if (id != cauHoi.MaCauHoi)
            {
                return NotFound();
            }
            ModelState.Remove("MaPhanNavigation");
            if (ModelState.IsValid)
            {
                try
                {
                    cauHoi.NgaySua = DateTime.Now;
                    _context.Update(cauHoi);
                    var cauTraLoiList = await _context.CauTraLois.Where(ct => ct.MaCauHoi == id).ToListAsync();

                    // Cập nhật thông tin của các câu trả lời
                    foreach (var cauTraLoi in cauTraLoiList)
                    {
                        //switch (cauTraLoi.ThuTu)
                        //{
                        //    case 1:
                        //        cauTraLoi.NoiDung = DAA;
                        //        cauTraLoi.LaDapAn = (dapAnDung == "DAA");
                        //        break;
                        //    case 2:
                        //        cauTraLoi.NoiDung = DAB;
                        //        cauTraLoi.LaDapAn = (dapAnDung == "DAB");
                        //        break;
                        //    case 3:
                        //        cauTraLoi.NoiDung = DAC;
                        //        cauTraLoi.LaDapAn = (dapAnDung == "DAC");
                        //        break;
                        //    case 4:
                        //        cauTraLoi.NoiDung = DAD;
                        //        cauTraLoi.LaDapAn = (dapAnDung == "DAD");
                        //        break;
                        //    default:
                        //        break;
                        //}
                        _context.Update(cauTraLoi);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CauHoiExists(cauHoi.MaCauHoi))
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
            ViewData["MaPhan"] = new SelectList(_context.Phans, "MaPhan", "TenPhan", cauHoi.MaPhan);
            return View(cauHoi);
        }

        // GET: CauHoi/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cauHoi = await _context.CauHois
                .Include(c => c.MaPhanNavigation)
                .FirstOrDefaultAsync(m => m.MaCauHoi == id);
            if (cauHoi == null)
            {
                return NotFound();
            }
            ViewBag.CauTraLoi = _context.CauTraLois.Where(p => p.MaCauHoi == id).ToList();

            return View(cauHoi);

        }

        // POST: CauHoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            //var cauTraLois = await _context.CauTraLois.Include(p => p.MaCauHoiNavigation).ToListAsync();
            //if (cauTraLois.Count() > 0)
            //{
            //    foreach (var item in cauTraLois)
            //    {
            //        _context.CauTraLois.Remove(item);
            //    }
            //}
            _delete.DeleteCH(id);
            //var cauHoi = await _context.CauHois.FindAsync(id);
            //if (cauHoi != null)
            //{
            //    _context.CauHois.Remove(cauHoi);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CauHoiExists(Guid id)
        {
            return _context.CauHois.Any(e => e.MaCauHoi == id);
        }
        public async Task<IActionResult> Choose()
        {
            return View();
        }
        
        List<CauHoi> ParseWordFile(string filePath, Guid maphan)
        {
            List<CauHoi> questions = new List<CauHoi>();


            using (DocX document = DocX.Load(filePath))
            {

                string fullText = document.Text;
                int startIndex = 0;
                
                while ((startIndex = fullText.IndexOf("[<g>]", startIndex)) != -1)
                {
                    int endIndex = fullText.IndexOf("[</g>]", startIndex);
                    if (endIndex == -1)
                        break;
                    string groupContent = fullText.Substring(startIndex, endIndex - startIndex + "[</g>]".Length);
                    questions.AddRange(ParseQuestions(groupContent, maphan));
                    startIndex = endIndex + "[</g>]".Length;
                }
            }
            return questions;
        }

        List<CauHoi> ParseQuestions(string groupContent,Guid maphan)
        {
            Console.WriteLine(groupContent);
            List<CauHoi> questions = new List<CauHoi>();

            int questionStartIndex = groupContent.IndexOf("[<g>]") + "[<g>]".Length;
            string[] questionBlocks = groupContent.Substring(questionStartIndex).Split(new string[] { "[<br>]" }, StringSplitOptions.None);

            foreach (var questionBlock in questionBlocks)
            {
                if (string.IsNullOrWhiteSpace(questionBlock))
                    continue;

                var parsedQuestion = ParseQuestion(questionBlock.Trim(), maphan);
                questions.Add(parsedQuestion);
            }

            return questions;
        }
        CauHoi ParseQuestion(string questionContent, Guid maphan)
        {
            var questionTextMatch = Regex.Match(questionContent, @"^(.*?)(A\..*)$", RegexOptions.Singleline);
            string questionText = questionTextMatch.Success ? questionTextMatch.Groups[1].Value.Trim() : questionContent.Trim();
            string answerText = questionTextMatch.Success ? questionTextMatch.Groups[2].Value.Trim() : string.Empty;

            ExtractAnswers(answerText, out string answerA, out string answerB, out string answerC, out string answerD);

            List<String> Lists = new List<String>();
            Lists.Add(answerA.Contains("[</g>]")?answerA.Replace("[</g>]",""):answerA);
            Lists.Add(answerB.Contains("[</g>]") ? answerB.Replace("[</g>]", "") : answerB);
            Lists.Add(answerC.Contains("[</g>]") ? answerC.Replace("[</g>]", "") : answerC);
            Lists.Add(answerD.Contains("[</g>]") ? answerD.Replace("[</g>]", "") : answerD);
            var tempMaCauHoi = Guid.NewGuid();
            CauHoi question = new CauHoi
            {
                MaSoCauHoi = _context.CauHois.Count() > 0 ? _context.CauHois.Max(p => p.MaSoCauHoi) + 1 : 1,
                NoiDung = questionText,
                CapDo = 0,
                DoPhanCachCauHoi = 0,
                SoCauHoiCon = 0,
                MaPhan = maphan,
                MaCauHoiCha = Guid.Empty,
                XoaTamCauHoi = true,
                SoLanDuocThi = 0,
                SoLanDung = 100,
                NgayTao = DateTime.Now,
                NgaySua = DateTime.Now,
                MaCauHoi = tempMaCauHoi,
                CauTraLois = Lists.Select((item, index) => new CauTraLoi
                {
                    MaCauHoi = tempMaCauHoi,
                    MaCauTraLoi = Guid.NewGuid(),
                    NoiDung = item.Contains("_") ? item.Replace("_", "") : item,
                    ThuTu = index + 1,
                    LaDapAn = item.Contains("_") ? true : false,
                }).ToList()
            };


            return question;
        }
        void ExtractAnswers(string answerText, out string answerA, out string answerB, out string answerC, out string answerD)
        {
            answerA = answerB = answerC = answerD = string.Empty;
            string pattern = @"[A-D]\.\s*([^\t]+)";
            MatchCollection matches = Regex.Matches(answerText, pattern);

            if (matches.Count >= 4)
            {
                answerA = matches[0].Groups[1].Value.Trim();
                answerB = matches[1].Groups[1].Value.Trim();
                answerC = matches[2].Groups[1].Value.Trim();
                answerD = matches[3].Groups[1].Value.Trim();
            }
        }
        [HttpGet]
        public async Task<IActionResult> QuesFromFile()
        {
            var Users = _userManager.Users.FirstOrDefault(p => p.UserName == User.Identity.Name);

            var phansByMonHoc = _context.Phans.Include(p => p.MaMonHocNavigation.MaKhoaNavigation).OrderBy(p => p.MaMonHocNavigation.TenMonHoc).Where(p => p.MaMonHocNavigation.MaKhoaNavigation.MaKhoa == Users.KhoaID).ToList();

            var groupedPhans = phansByMonHoc.GroupBy(p => p.MaMonHocNavigation.TenMonHoc)
                                            .Select(g => new
                                            {
                                                GroupName = g.Key,
                                                Items = g.Select(p => new SelectListItem
                                                {
                                                    Value = p.MaPhan.ToString(),
                                                    Text = p.TenPhan
                                                }).ToList()
                                            }).ToList();

            List<SelectListItem> maPhanList = new List<SelectListItem>();
            foreach (var group in groupedPhans)
            {
                maPhanList.Add(new SelectListItem { Text = group.GroupName, Disabled = true });
                foreach (var item in group.Items)
                {
                    maPhanList.Add(item);
                }
            }

            ViewData["MaPhan"] = maPhanList;
            var clos = _context.Clos.ToList(); // Lấy danh sách các đối tượng từ _context.Clos

            // Tạo một danh sách mới bằng cách thêm một mục mới vào đầu tiên
            clos.Insert(0, new Clo { CloId = 0, CloName = "Chưa Chọn CLO" });

            // Tạo SelectList từ danh sách đã được cập nhật
            ViewBag.Clos = new SelectList(clos, "CloId", "CloName");
            ViewData["MonHoc"] = new SelectList(_context.MonHocs, "MaMonHoc", "TenMonHoc");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> QuesFromFile(CauHoi cauhoi, IFormFile fileUpload)
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "docx");
                //đổi tên sau khi upload
                var filePath = Path.Combine(uploadsFolder, fileUpload.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(fileStream);
                }
            }
            string asd = fileUpload.FileName; 
            string filepath = Path.Combine(_environment.WebRootPath, "docx", $"{asd}");
            List<CauHoi> cauhois = ParseWordFile(filepath, cauhoi.MaPhan);
            cauhoiss = cauhois;
            return RedirectToAction(nameof(QuestionList)); 
        }
        public async Task<IActionResult> SaveToDatabase()
        {
            
            foreach(var i in cauhoiss)
            {
                _context.Add(i);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> QuestionList()
        {
            if (cauhoiss.Count <= 0)
            {
                return RedirectToAction(nameof(Choose));
            }
            var deThiDetails = new List<DeThiDetail>();

            foreach (var i in cauhoiss)
            {

                var dethi = new DeThiDetail
                {
                    CauHoi = i.NoiDung
                };

                var cauTraLois = i.CauTraLois
                    .Where(c => c.MaCauHoi == i.MaCauHoi)
                    .ToList();
                
                foreach (var j in cauTraLois)
                {
                    
                    switch (j.ThuTu)
                    {
                        case 1:
                            dethi.DAA = j.NoiDung;
                            if (j.LaDapAn)
                            {
                                dethi.DapAn = "A";
                            }
                            break;
                        case 2:
                            dethi.DAB = j.NoiDung;
                            if (j.LaDapAn)
                            {
                                dethi.DapAn = "B";
                            }
                            break;
                        case 3:
                            dethi.DAC = j.NoiDung;
                            if (j.LaDapAn)
                            {
                                dethi.DapAn = "C";
                            }
                            break;
                        case 4:
                            dethi.DAD = j.NoiDung;
                            if (j.LaDapAn)
                            {
                                dethi.DapAn = "D";
                            }
                            break;
                        default:
                            break;
                    }
                }

                deThiDetails.Add(dethi);
            }
            return View(deThiDetails);
        }
    }
}
