using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class VNamApdungChuongTrinh
{
    public string? TenChuongTrinh { get; set; }

    public string? MaChuongTrinhDaoTao { get; set; }

    public int? SoTinChiToiThieuDeTotNghiep { get; set; }

    public int? TongHocPhiToanKhoa { get; set; }

    public DateOnly? NamApDung { get; set; }

    public int? ChiTieuTuyenSinhHangNam { get; set; }
}
