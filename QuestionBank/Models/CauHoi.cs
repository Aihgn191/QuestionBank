using System;
using System.Collections.Generic;

namespace QuestionBank.Models;

public partial class CauHoi
{
    public Guid MaCauHoi { get; set; }

    public Guid MaPhan { get; set; }

    public int MaSoCauHoi { get; set; }

    public string? NoiDung { get; set; }

    public bool HoanVi { get; set; }

    public short CapDo { get; set; }

    public int SoCauHoiCon { get; set; }

    public double? DoPhanCachCauHoi { get; set; }

    public Guid? MaCauHoiCha { get; set; }

    public bool? XoaTamCauHoi { get; set; }

    public int? SoLanDuocThi { get; set; }

    public int? SoLanDung { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgaySua { get; set; }

    public virtual ICollection<CauTraLoi> CauTraLois { get; set; } = new List<CauTraLoi>();
    public int? CloId { get; set; }
    public Clo? Clo { get; set; }
    public virtual ICollection<ChiTietDeThi> ChiTietDeThis { get; set; } = new List<ChiTietDeThi>();

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual Phan MaPhanNavigation { get; set; } = null!;
}
