using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDanhSachVanBangChungChi
{
    public int IdDanhSachVanBangChungChi { get; set; }

    public int? IdHocVien { get; set; }

    public string? TenVanBang { get; set; }

    public int? IdChuongTrinhDaoTao { get; set; }

    public string? TenDonViBangCap { get; set; }

    public DateOnly? NgayCap { get; set; }

    public string? NamTotNghiep { get; set; }

    public int? IdLoaiTotNghiep { get; set; }

    public string? SoQuyetDinhCongNhanTotNghiep { get; set; }

    public DateOnly? NgayQuyetDinhCongNhanTotNghiep { get; set; }

    public string? SoHieuVanBang { get; set; }

    public string? SoVaoSoGocCapVanBang { get; set; }

    public string? SoQuyetDinhThanhLapHoiDongDanhGiaLuanVan { get; set; }

    public DateOnly? NgayBaoVe { get; set; }

    public string? LinkFileScan { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmLoaiTotNghiep? IdLoaiTotNghiepNavigation { get; set; }
}
