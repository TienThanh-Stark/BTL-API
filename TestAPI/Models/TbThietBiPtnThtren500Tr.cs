using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbThietBiPtnThtren500Tr
{
    public int IdThietBiPtnTh { get; set; }

    public string? MaThietBi { get; set; }

    public int? IdCongTrinhCsvc { get; set; }

    public string? TenThietBi { get; set; }

    public string? NamSanXuat { get; set; }

    public int? IdQuocGiaXuatXu { get; set; }

    public string? HangSanXuat { get; set; }

    public int? SoLuongThietBiCungLoai { get; set; }

    public string? NamDuaVaoSuDung { get; set; }

    public virtual TbCongTrinhCoSoVatChat? IdCongTrinhCsvcNavigation { get; set; }

    public virtual DmQuocTich? IdQuocGiaXuatXuNavigation { get; set; }
}
