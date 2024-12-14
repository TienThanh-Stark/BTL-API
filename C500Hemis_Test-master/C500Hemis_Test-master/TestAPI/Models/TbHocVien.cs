using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbHocVien
{
    public int IdHocVien { get; set; }

    public string? MaHocVien { get; set; }

    public int? IdNguoi { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? SoSoBaoHiem { get; set; }

    public int? IdLoaiKhuyetTat { get; set; }

    public int? IdTinh { get; set; }

    public int? IdHuyen { get; set; }

    public int? IdXa { get; set; }

    public string? NoiSinh { get; set; }

    public string? QueQuan { get; set; }

    public virtual DmHuyen? IdHuyenNavigation { get; set; }

    public virtual DmLoaiKhuyetTat? IdLoaiKhuyetTatNavigation { get; set; }

    public virtual TbNguoi? IdNguoiNavigation { get; set; }

    public virtual DmTinh? IdTinhNavigation { get; set; }

    public virtual DmXa? IdXaNavigation { get; set; }

    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>();

    public virtual ICollection<TbDanhSachVanBangChungChi> TbDanhSachVanBangChungChis { get; set; } = new List<TbDanhSachVanBangChungChi>();

    public virtual ICollection<TbKyLuatNguoiHoc> TbKyLuatNguoiHocs { get; set; } = new List<TbKyLuatNguoiHoc>();

    public virtual ICollection<TbNguoiHocVayTinDung> TbNguoiHocVayTinDungs { get; set; } = new List<TbNguoiHocVayTinDung>();

    public virtual ICollection<TbThongTinHocBong> TbThongTinHocBongs { get; set; } = new List<TbThongTinHocBong>();

    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();

    public virtual ICollection<TbThongTinNguoiHocGdtc> TbThongTinNguoiHocGdtcs { get; set; } = new List<TbThongTinNguoiHocGdtc>();

    public virtual ICollection<TbThongTinViPham> TbThongTinViPhams { get; set; } = new List<TbThongTinViPham>();

    public virtual ICollection<TbThongTinViecLamSauTotNghiep> TbThongTinViecLamSauTotNghieps { get; set; } = new List<TbThongTinViecLamSauTotNghiep>();
}
