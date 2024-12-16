using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbCanBo
{
    public int IdCanBo { get; set; }

    public int? IdNguoi { get; set; }

    public string? MaCanBo { get; set; }

    public int? IdChucVuCongTac { get; set; }

    public string? SoBaoHiemXaHoi { get; set; }

    public int? IdXa { get; set; }

    public int? IdHuyen { get; set; }

    public int? IdTinh { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public int? IdTrangThaiLamViec { get; set; }

    public DateOnly? NgayChuyenTrangThai { get; set; }

    public string? SoQuyetDinhHuuNghiViec { get; set; }

    public DateOnly? NgayQuyetDinhHuuNghiViec { get; set; }

    public string? HinhThucChuyenDen { get; set; }

    public DateOnly? NgayKetThucTamNghi { get; set; }

    public int? IdChucDanhNgheNghiep { get; set; }

    public int? IdChucDanhGiangVien { get; set; }

    public int? IdChucDanhNghienCuuKhoaHoc { get; set; }

    public int? IdNgach { get; set; }

    public string? CoQuanCongTac { get; set; }

    public DateOnly? NgayTuyenDung { get; set; }

    public bool? ChungChiSuPhamGiangVien { get; set; }

    public bool? LaCongChuc { get; set; }

    public bool? LaVienChuc { get; set; }

    public bool? CoDayMonMacLeNin { get; set; }

    public bool? CoDayMonSuPham { get; set; }

    public string? SoGiayPhepLaoDong { get; set; }

    public int? ThamNienCongTac { get; set; }

    public string? TenDoanhNghiep { get; set; }

    public int? NamKinhNghiemGiangDay { get; set; }

    public bool? GiangVienDapUngTt03 { get; set; }

    public virtual DmChucDanhGiangVien? IdChucDanhGiangVienNavigation { get; set; }

    public virtual DmChucDanhNgheNghiep? IdChucDanhNgheNghiepNavigation { get; set; }

    public virtual DmChucDanhNckh? IdChucDanhNghienCuuKhoaHocNavigation { get; set; }

    public virtual DmChucVu? IdChucVuCongTacNavigation { get; set; }

    public virtual DmHuyen? IdHuyenNavigation { get; set; }

    public virtual DmNgach? IdNgachNavigation { get; set; }

    public virtual TbNguoi? IdNguoiNavigation { get; set; }

    public virtual DmTinh? IdTinhNavigation { get; set; }

    public virtual DmTrangThaiCanBo? IdTrangThaiLamViecNavigation { get; set; }

    public virtual DmXa? IdXaNavigation { get; set; }

    public virtual ICollection<TbCanBoHuongDanThanhCongSinhVien> TbCanBoHuongDanThanhCongSinhViens { get; set; } = new List<TbCanBoHuongDanThanhCongSinhVien>();

    public virtual ICollection<TbChucDanhKhoaHocCuaCanBo> TbChucDanhKhoaHocCuaCanBos { get; set; } = new List<TbChucDanhKhoaHocCuaCanBo>();

    public virtual ICollection<TbDanhGiaXepLoaiCanBo> TbDanhGiaXepLoaiCanBos { get; set; } = new List<TbDanhGiaXepLoaiCanBo>();

    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo> TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo>();

    public virtual ICollection<TbDienBienLuong> TbDienBienLuongs { get; set; } = new List<TbDienBienLuong>();

    public virtual ICollection<TbDoiTuongChinhSachCanBo> TbDoiTuongChinhSachCanBos { get; set; } = new List<TbDoiTuongChinhSachCanBo>();

    public virtual ICollection<TbDonViCongTacCuaCanBo> TbDonViCongTacCuaCanBos { get; set; } = new List<TbDonViCongTacCuaCanBo>();

    public virtual ICollection<TbDonViThinhGiangCuaCanBo> TbDonViThinhGiangCuaCanBos { get; set; } = new List<TbDonViThinhGiangCuaCanBo>();

    public virtual ICollection<TbGiangVienNn> TbGiangVienNns { get; set; } = new List<TbGiangVienNn>();

    public virtual ICollection<TbGiaoVienQpan> TbGiaoVienQpans { get; set; } = new List<TbGiaoVienQpan>();

    public virtual ICollection<TbGvduocCuDiDaoTao> TbGvduocCuDiDaoTaos { get; set; } = new List<TbGvduocCuDiDaoTao>();

    public virtual ICollection<TbHopDongThinhGiang> TbHopDongThinhGiangs { get; set; } = new List<TbHopDongThinhGiang>();

    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();

    public virtual ICollection<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo> TbKhoaBoiDuongTapHuanThamGiaCuaCanBos { get; set; } = new List<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo>();

    public virtual ICollection<TbKyLuatCanBo> TbKyLuatCanBos { get; set; } = new List<TbKyLuatCanBo>();

    public virtual ICollection<TbLinhVucNghienCuuCuaCanBo> TbLinhVucNghienCuuCuaCanBos { get; set; } = new List<TbLinhVucNghienCuuCuaCanBo>();

    public virtual ICollection<TbNganhDungTenGiangDay> TbNganhDungTenGiangDays { get; set; } = new List<TbNganhDungTenGiangDay>();

    public virtual ICollection<TbNganhGiangDayCuaCanBo> TbNganhGiangDayCuaCanBos { get; set; } = new List<TbNganhGiangDayCuaCanBo>();

    public virtual ICollection<TbPhuCap> TbPhuCaps { get; set; } = new List<TbPhuCap>();

    public virtual ICollection<TbQuaTrinhCongTacCuaCanBo> TbQuaTrinhCongTacCuaCanBos { get; set; } = new List<TbQuaTrinhCongTacCuaCanBo>();

    public virtual ICollection<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; } = new List<TbQuaTrinhDaoTaoCuaCanBo>();

    public virtual ICollection<TbThanhPhanThamGiaDoanCongTac> TbThanhPhanThamGiaDoanCongTacs { get; set; } = new List<TbThanhPhanThamGiaDoanCongTac>();

    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhIdNguoiHuongDanChinhNavigations { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();

    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhIdNguoiHuongDanPhuNavigations { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();

    public virtual ICollection<TbTrinhDoTiengDanToc> TbTrinhDoTiengDanTocs { get; set; } = new List<TbTrinhDoTiengDanToc>();
}
