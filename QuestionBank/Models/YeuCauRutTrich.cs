﻿using System;
using System.Collections.Generic;

namespace QuestionBank.Models;

public partial class YeuCauRutTrich
{
    public Guid MaYeuCauDe { get; set; }

    public string? HoTenGiaoVien { get; set; }

    public string? NoiDungRutTrich { get; set; }

    public DateTime? NgayLay { get; set; }
}
