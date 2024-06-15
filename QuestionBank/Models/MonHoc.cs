using System;
using System.Collections.Generic;

namespace QuestionBank.Models;

public partial class MonHoc
{
    public Guid MaMonHoc { get; set; }

    public Guid MaKhoa { get; set; }

    public string MaSoMonHoc { get; set; } = null!;

    public string TenMonHoc { get; set; } = null!;

    public bool? XoaTamMonHoc { get; set; }

    public virtual ICollection<DeThi> DeThis { get; set; } = new List<DeThi>();

    public virtual Khoa MaKhoaNavigation { get; set; } = null!;

    public virtual ICollection<Phan> Phans { get; set; } = new List<Phan>();
}
