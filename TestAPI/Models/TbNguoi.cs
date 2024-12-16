using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbNguoi
{
    public int IdNguoi { get; set; }

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public int? IdQuocTich { get; set; }

    public string? SoCccd { get; set; }

    public DateOnly? NgayCapCccd { get; set; }

    public string? NoiCapCccd { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public int? IdGioiTinh { get; set; }

    public int? IdDanToc { get; set; }

    public int? IdTonGiao { get; set; }

    public DateOnly? NgayVaoDoan { get; set; }

    public DateOnly? NgayVaoDang { get; set; }

    public DateOnly? NgayVaoDangChinhThuc { get; set; }

    public DateOnly? NgayNhapNgu { get; set; }

    public DateOnly? NgayXuatNgu { get; set; }

    public int? IdThuongBinhHang { get; set; }

    public int? IdGiaDinhChinhSach { get; set; }

    public int? IdChucDanhKhoaHoc { get; set; }

    public int? IdTrinhDoDaoTao { get; set; }

    public int? IdChuyenMonDaoTao { get; set; }

    public int? IdNgoaiNgu { get; set; }

    public int? IdKhungNangLucNgoaiNguc { get; set; }

    public int? IdTrinhDoLyLuanChinhTri { get; set; }

    public int? IdTrinhDoQuanLyNhaNuoc { get; set; }

    public int? IdTrinhDoTinHoc { get; set; }

    public virtual DmChucDanhKhoaHoc? IdChucDanhKhoaHocNavigation { get; set; }

    public virtual DmNganhDaoTao? IdChuyenMonDaoTaoNavigation { get; set; }

    public virtual DmDanToc? IdDanTocNavigation { get; set; }

    public virtual DmHoGiaDinhChinhSach? IdGiaDinhChinhSachNavigation { get; set; }

    public virtual DmGioiTinh? IdGioiTinhNavigation { get; set; }

    public virtual DmKhungNangLucNgoaiNgu? IdKhungNangLucNgoaiNgucNavigation { get; set; }

    public virtual DmNgoaiNgu? IdNgoaiNguNavigation { get; set; }

    public virtual DmQuocTich? IdQuocTichNavigation { get; set; }

    public virtual DmHangThuongBinh? IdThuongBinhHangNavigation { get; set; }

    public virtual DmTonGiao? IdTonGiaoNavigation { get; set; }

    public virtual DmTrinhDoDaoTao? IdTrinhDoDaoTaoNavigation { get; set; }

    public virtual DmTrinhDoLyLuanChinhTri? IdTrinhDoLyLuanChinhTriNavigation { get; set; }

    public virtual DmTrinhDoQuanLyNhaNuoc? IdTrinhDoQuanLyNhaNuocNavigation { get; set; }

    public virtual DmTrinhDoTinHoc? IdTrinhDoTinHocNavigation { get; set; }

    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    public virtual ICollection<TbDoiTuongThamGium> TbDoiTuongThamGia { get; set; } = new List<TbDoiTuongThamGium>();

    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
}
