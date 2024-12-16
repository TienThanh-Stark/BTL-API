using System;
using System.Collections.Generic;

namespace TestAPI.Models.tracnghiem;

public partial class TbDeThi
{
    public int Id { get; set; }

    public DateOnly? NgayThi { get; set; }

    public int? ThoiGianThi { get; set; }

    public string? TenDeThi { get; set; }

    public int? SoLuongCauKho { get; set; }

    public int? SoLuongCauHoi { get; set; }

    public virtual ICollection<TbDeThiCauHoi> TbDeThiCauHois { get; set; } = new List<TbDeThiCauHoi>();
}
