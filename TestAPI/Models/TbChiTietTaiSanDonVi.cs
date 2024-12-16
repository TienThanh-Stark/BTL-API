using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbChiTietTaiSanDonVi
{
    public int IdChiTietTaiSanDonVi { get; set; }

    public int? IdTaiSanDonVi { get; set; }

    public string? MaTaiSan { get; set; }

    public string? TenTaiSan { get; set; }

    public int? NguyenGia { get; set; }

    public int? IdTinhTrangThietBi { get; set; }

    public int? IdChuSoHuu { get; set; }

    public virtual DmChuSoHuu? IdChuSoHuuNavigation { get; set; }

    public virtual TbTaiSanDonVi? IdTaiSanDonViNavigation { get; set; }

    public virtual DmTinhTrangThietBi? IdTinhTrangThietBiNavigation { get; set; }
}
