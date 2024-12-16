using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbThongTinHocTapNghienCuuSinh
{
    public int IdThongTinHocTapNghienCuuSinh { get; set; }

    public int? IdHocVien { get; set; }

    public int? IdDoiTuongDauVao { get; set; }

    public int? IdSinhVienNam { get; set; }

    public int? IdChuongTrinhDaoTao { get; set; }

    public int? IdLoaiHinhDaoTao { get; set; }

    public DateOnly? DaoTaoTuNam { get; set; }

    public DateOnly? DaoTaoDenNam { get; set; }

    public DateOnly? NgayNhapHoc { get; set; }

    public int? IdTrangThaiHoc { get; set; }

    public DateOnly? NgayChuyenTrangThai { get; set; }

    public string? SoQuyetDinhThoiHoc { get; set; }

    public DateOnly? NgayBaoVeCapTruong { get; set; }

    public DateOnly? NgayBaoVeCapCoSo { get; set; }

    public string? QuyChuanNguoiHuongDan { get; set; }

    public int? IdNguoiHuongDanChinh { get; set; }

    public int? IdNguoiHuongDanPhu { get; set; }

    public string? SoQuyetDinhCongNhan { get; set; }

    public DateOnly? NgayQuyetDinhCongNhan { get; set; }

    public int? IdLoaiTotNghiep { get; set; }

    public string? SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo { get; set; }

    public DateOnly? NgayQuyetDinhThanhLapHoiDongBaoVeCapCoSo { get; set; }

    public string? SoQuyetDinhThanhLapHoiDongBaoVeCapTruong { get; set; }

    public DateOnly? NgayQuyetDinhThanhLapHoiDongBaoVeCapTruong { get; set; }

    public string? TenLuanVan { get; set; }

    public virtual DmChuongTrinhDaoTao? IdChuongTrinhDaoTaoNavigation { get; set; }

    public virtual DmDoiTuongDauVao? IdDoiTuongDauVaoNavigation { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmLoaiHinhDaoTao? IdLoaiHinhDaoTaoNavigation { get; set; }

    public virtual DmLoaiTotNghiep? IdLoaiTotNghiepNavigation { get; set; }

    public virtual TbCanBo? IdNguoiHuongDanChinhNavigation { get; set; }

    public virtual TbCanBo? IdNguoiHuongDanPhuNavigation { get; set; }

    public virtual DmSinhVienNam? IdSinhVienNamNavigation { get; set; }

    public virtual DmTrangThaiHoc? IdTrangThaiHocNavigation { get; set; }
}
