using QuestionBank.Models;

namespace QuestionBank.Models
{
    public class Delete
    {
        private readonly HutechQuestionBank _context;

        public Delete(HutechQuestionBank context)
        {
            _context = context;
        }



        public void DeleteCH(Guid id)
        {
            var ctl = _context.CauTraLois.Where(p => p.MaCauHoi == id).ToList();
            if (ctl.Count() > 0)
            {
                foreach (var ctlItem in ctl)
                {
                    _context.Remove(ctlItem);
                }
            }
            var cauHoi = _context.CauHois.Find(id);
            if (cauHoi != null)
            {
                _context.CauHois.Remove(cauHoi);
            }

            _context.SaveChanges();

        }
        public void DeletePhan(Guid id)
        {
            var ctl = _context.CauHois.Where(p => p.MaPhan == id).ToList();
            if (ctl.Count() > 0)
            {
                foreach (var ctlItem in ctl)
                {
                    DeleteCH(ctlItem.MaCauHoi);
                }
            }
            var Phan = _context.Phans.Find(id);
            if (Phan != null)
            {
                _context.Phans.Remove(Phan);
            }

            _context.SaveChanges();
        }
        public void DeleteMH(Guid id)
        {
            var ctl = _context.Phans.Where(p => p.MaMonHoc == id).ToList();
            if (ctl.Count() > 0)
            {
                foreach (var ctlItem in ctl)
                {
                    DeletePhan(ctlItem.MaPhan);
                }
            }
            var MH = _context.MonHocs.Find(id);
            if (MH != null)
            {
                _context.MonHocs.Remove(MH);
            }

            _context.SaveChanges();

        }
        public void DeteleKhoa(Guid id)
        {
            var ctl = _context.MonHocs.Where(p => p.MaKhoa == id).ToList();
            if (ctl.Count() > 0)
            {
                foreach (var ctlItem in ctl)
                {
                    DeleteMH(ctlItem.MaMonHoc);
                }
                _context.SaveChanges();
            }
            var Khoa = _context.Khoas.Find(id);
            if (Khoa != null)
            {
                _context.Khoas.Remove(Khoa);
            }

            _context.SaveChanges();
        }
    }
}
