using System;
using System.Collections.Generic;

namespace QuestionBank.Models;

public partial class File
{
    public Guid MaFile { get; set; }

    public Guid? MaCauHoi { get; set; }

    public string? TenFile { get; set; }

    public int? LoaiFile { get; set; }

    public Guid? MaCauTraLoi { get; set; }

    public virtual CauHoi? MaCauHoiNavigation { get; set; }
}
