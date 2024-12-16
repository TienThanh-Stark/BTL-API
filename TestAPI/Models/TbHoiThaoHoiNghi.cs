using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbHoiThaoHoiNghi
{
    public int IdHoiThaoHoiNghi { get; set; }

    public string? MaHoiThaoHoiNghi { get; set; }

    public string? TenHoiThaoHoiNghi { get; set; }

    public string? CoQuanCoThamQuyenCapPhep { get; set; }

    public string? MucTieu { get; set; }

    public string? NoiDung { get; set; }

    public int? SoLuongDaiBieuThamDu { get; set; }

    public int? SoLuongDaiBieuQuocTeThamDu { get; set; }

    public DateOnly? ThoiGianToChuc { get; set; }

    public string? DiaDiemToChuc { get; set; }

    public int? IdNguonKinhPhiHoiThao { get; set; }

    public string? DonViChuTri { get; set; }

    public virtual DmNguonKinhPhi? IdNguonKinhPhiHoiThaoNavigation { get; set; }
}
