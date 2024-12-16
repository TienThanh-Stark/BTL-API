using System;
using System.Collections.Generic;

namespace TestAPI.Models.tracnghiem;

public partial class TbKetQua
{
    public int Id { get; set; }

    public string? MaSinhVien { get; set; }

    public string? DapAn { get; set; }

    public int? MaDeThiCauHoi { get; set; }

    public int? IdSinhVien { get; set; }

    public virtual TbThanhVien? IdSinhVienNavigation { get; set; }

    public virtual TbDeThiCauHoi? MaDeThiCauHoiNavigation { get; set; }
}
