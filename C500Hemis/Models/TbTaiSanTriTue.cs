using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbTaiSanTriTue
{
    public int IdTaiSanTriTue { get; set; }

    public int? IdNhiemVuKhcn { get; set; }

    public string? MaGiaiPhapSangChe { get; set; }

    public string? TenTaiSanTriTue { get; set; }

    public string? ToChucCapBangGiayChungNhan { get; set; }

    public int? IdLoaiTaiSanTriTue { get; set; }

    public DateOnly? NgayCapBangGiayChungNhan { get; set; }

    public string? ToChucCapBang { get; set; }

    public int? SoBang { get; set; }

    public DateOnly? NgayCap { get; set; }

    public int? SoDon { get; set; }

    public DateOnly? NgayNopDon { get; set; }

    public string? QuyetDinhCapBangGiayChungNhan { get; set; }

    public string? CongBoBang { get; set; }

    public string? Ipc { get; set; }

    public string? ChuSoHuu { get; set; }

    public string? TacGiaSangCheGiaiPhap { get; set; }

    public string? TomTatNoiDungTaiSanTriTue { get; set; }

    public string? NguoiChuTri { get; set; }

    public string? NamDuocChapNhanDonHopLe { get; set; }

    public virtual DmLoaiTaiSanTriTue? IdLoaiTaiSanTriTueNavigation { get; set; }

    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }
}
