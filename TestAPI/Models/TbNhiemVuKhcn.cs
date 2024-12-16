using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbNhiemVuKhcn
{
    public int IdNhiemVuKhcn { get; set; }

    public string? MaNhiemVu { get; set; }

    public string? TenNhiemVu { get; set; }

    public int? IdCapQuanLyNhiemVu { get; set; }

    public int? IdCoQuanChuQuan { get; set; }

    public string? CoQuanChuTri { get; set; }

    public string? NguoiChuTri { get; set; }

    public int? IdPhanLoaiNhiemVu { get; set; }

    public string? ThuocNhiemVu { get; set; }

    public int? IdLinhVucNghienCuu { get; set; }

    public string? TongKinhPhiCuaNhiemVu { get; set; }

    public int? IdNguonKinhPhi { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public string? DanhGiaKetQuaNhiemVu { get; set; }

    public string? SanPhamChinhCuaNhiemVu { get; set; }

    public int? IdTinhTrangNhiemVu { get; set; }

    public virtual DmPhanCapNhiemVu? IdCapQuanLyNhiemVuNavigation { get; set; }

    public virtual DmCoQuanChuQuan? IdCoQuanChuQuanNavigation { get; set; }

    public virtual DmLinhVucNghienCuu? IdLinhVucNghienCuuNavigation { get; set; }

    public virtual DmNguonKinhPhi? IdNguonKinhPhiNavigation { get; set; }

    public virtual DmLoaiNhiemVu? IdPhanLoaiNhiemVuNavigation { get; set; }

    public virtual DmTinhTrangNhiemVu? IdTinhTrangNhiemVuNavigation { get; set; }

    public virtual ICollection<TbBaiBaoKhdaCongBo> TbBaiBaoKhdaCongBos { get; set; } = new List<TbBaiBaoKhdaCongBo>();

    public virtual ICollection<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; } = new List<TbChuyenGiaoCongNgheVaDaoTao>();

    public virtual ICollection<TbHoatDongBaoVeMoiTruong> TbHoatDongBaoVeMoiTruongs { get; set; } = new List<TbHoatDongBaoVeMoiTruong>();

    public virtual ICollection<TbSachDaXuatBan> TbSachDaXuatBans { get; set; } = new List<TbSachDaXuatBan>();

    public virtual ICollection<TbTaiSanTriTue> TbTaiSanTriTues { get; set; } = new List<TbTaiSanTriTue>();
}
