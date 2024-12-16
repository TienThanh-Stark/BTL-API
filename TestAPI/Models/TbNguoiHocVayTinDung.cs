using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbNguoiHocVayTinDung
{
    public int IdNguoiHocVayTinDung { get; set; }

    public int? IdHocVien { get; set; }

    public int? SoTienDuocVay { get; set; }

    public string? TenToChucTinDung { get; set; }

    public DateOnly? NgayVay { get; set; }

    public string? DiaChi { get; set; }

    public int? ThoiHanVay { get; set; }

    public int? TinhTrangVay { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmTuyChon? TinhTrangVayNavigation { get; set; }
}
