using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbDuLieuTrungTuyen
{
    public int IdDuLieuTrungTuyen { get; set; }

    public string? Cccd { get; set; }

    public string? HoVaTen { get; set; }

    public string? MaTuyenSinh { get; set; }

    public string? KhoaDaoTaoTrungTuyen { get; set; }

    public int? IdDoiTuongDauVao { get; set; }

    public int? IdDoiTuongUuTien { get; set; }

    public int? IdHinhThucTuyenSinh { get; set; }

    public int? IdKhuVuc { get; set; }

    public string? TruongThpt { get; set; }

    public string? ToHopMonTrungTuyen { get; set; }

    public double? DiemMon1 { get; set; }

    public double? DiemMon2 { get; set; }

    public double? DiemMon3 { get; set; }

    public double? DiemUuTien { get; set; }

    public double? TongDiemXetTuyen { get; set; }

    public string? SoQuyetDinhTrungTuyen { get; set; }

    public DateOnly? NgayBanHanhQuyetDinhTrungTuyen { get; set; }

    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc { get; set; }

    public string? NganhDaTotNghiepTrinhDoDaiHoc { get; set; }

    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi { get; set; }

    public string? NganhDaTotNghiepTrinhDoThacSi { get; set; }

    public virtual DmDoiTuongDauVao? IdDoiTuongDauVaoNavigation { get; set; }

    public virtual DmDoiTuongUuTien? IdDoiTuongUuTienNavigation { get; set; }

    public virtual DmHinhThucTuyenSinh? IdHinhThucTuyenSinhNavigation { get; set; }

    public virtual DmKhuVuc? IdKhuVucNavigation { get; set; }
}
