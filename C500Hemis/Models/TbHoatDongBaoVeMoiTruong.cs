using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbHoatDongBaoVeMoiTruong
{
    public int IdHoatDongBaoVeMoiTruong { get; set; }

    public int? IdNhiemVuKhcn { get; set; }

    public string? TenNhiemVuBvmt { get; set; }

    public int? IdCapQuanLyNhiemVu { get; set; }

    public int? IdCoQuanChuQuan { get; set; }

    public string? CoQuanChuTri { get; set; }

    public int? IdLoaiNhiemVuBaoVeMoiTruong { get; set; }

    public int? TongKinhPhiCuaNhiemVu { get; set; }

    public int? IdNguonKinhPhi { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public string? DanhGiaKetQuaNhiemVu { get; set; }

    public string? SanPhamChinhCuaNhiemVu { get; set; }

    public string? DonViThucHienLuuTruSanPham { get; set; }

    public int? IdTinhTrangNhiemVu { get; set; }

    public virtual DmPhanCapNhiemVu? IdCapQuanLyNhiemVuNavigation { get; set; }

    public virtual DmCoQuanChuQuan? IdCoQuanChuQuanNavigation { get; set; }

    public virtual DmLoaiNhiemVuBaoVeMoiTruong? IdLoaiNhiemVuBaoVeMoiTruongNavigation { get; set; }

    public virtual DmNguonKinhPhi? IdNguonKinhPhiNavigation { get; set; }

    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }

    public virtual DmTinhTrangNhiemVu? IdTinhTrangNhiemVuNavigation { get; set; }
}
