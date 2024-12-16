using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbThuVienTrungTamHocLieu
{
    public int IdThuVienTrungTamHocLieu { get; set; }

    public string? MaThuVienTrungTamHocLieu { get; set; }

    public string? TenThuVienTrungTamHocLieu { get; set; }

    public string? NamDuaVaoSuDung { get; set; }

    public double? DienTich { get; set; }

    public double? DienTichPhongDoc { get; set; }

    public int? SoPhongDoc { get; set; }

    public int? SoLuongMayTinh { get; set; }

    public int? SoLuongChoNgoi { get; set; }

    public int? SoLuongSach { get; set; }

    public int? SoLuongTapChi { get; set; }

    public int? SoLuongSachDienTu { get; set; }

    public int? SoLuongTapChiDienTu { get; set; }

    public int? SoLuonngThuVienDienTuLienKetNn { get; set; }

    public int? IdTinhTrangCsvc { get; set; }

    public int? IdHinhThucSoHuu { get; set; }

    public int? SoLuongDauSach { get; set; }

    public int? SoLuongDauTapChi { get; set; }

    public int? SoLuongDauSachDienTu { get; set; }

    public int? SoLuongDauTapChiDienTu { get; set; }

    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }

    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }
}
