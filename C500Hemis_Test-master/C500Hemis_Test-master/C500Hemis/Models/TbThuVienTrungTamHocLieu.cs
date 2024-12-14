using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThuVienTrungTamHocLieu
{
    public int IdThuVienTrungTamHocLieu { get; set; }

    public string? MaThuVienTrungTamHocLieu { get; set; }
    [DisplayName("Mã Thư Viện Trung Tâm Học Liệu")]
    public string? TenThuVienTrungTamHocLieu { get; set; }
    [DisplayName("Tên Thư Viện")]
    public string? NamDuaVaoSuDung { get; set; }
    [DisplayName("Năm Đưa Vào Sử Dụng")]
    public double? DienTich { get; set; }
    [DisplayName("Diện Tích")]
    public double? DienTichPhongDoc { get; set; }
    [DisplayName("Diện Tích Phòng Học")]
    public int? SoPhongDoc { get; set; }
    [DisplayName("Số Phòng Đọc")]
    public int? SoLuongMayTinh { get; set; }
    [DisplayName("Số Lượng Máy Tính")]
    public int? SoLuongChoNgoi { get; set; }
    [DisplayName("Số Lượng Chỗ")]
    public int? SoLuongSach { get; set; }
    [DisplayName("Số Lượng Sách")]
    public int? SoLuongTapChi { get; set; }
    [DisplayName("Số Lượng Tạp Chí")]
    public int? SoLuongSachDienTu { get; set; }
    [DisplayName("Số Lượng Sách Điện Tử")]
    public int? SoLuongTapChiDienTu { get; set; }
    [DisplayName("Số Lượng Tạp Chí Điện Tử")]
    public int? SoLuonngThuVienDienTuLienKetNn { get; set; }
    [DisplayName("Số Lượng Thư Viện Điện Tử Liên Kết")]
    public int? IdTinhTrangCsvc { get; set; }
    [DisplayName("Tình Trạng Cơ Sở Vật Chất")]
    public int? IdHinhThucSoHuu { get; set; }
    [DisplayName("Hình Thức Sở Hữu")]
    public int? SoLuongDauSach { get; set; }
    [DisplayName("Số Lượng Đầu Sách")]
    public int? SoLuongDauTapChi { get; set; }
    [DisplayName("Số Lượng Đầu Tạp Chí")]
    public int? SoLuongDauSachDienTu { get; set; }
    [DisplayName("Số Lượng Sách Điện Tử")]
    public int? SoLuongDauTapChiDienTu { get; set; }
    [DisplayName("Số Lượng Đầu Tạp Chí Điện Tử")]
    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }

    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }
}
