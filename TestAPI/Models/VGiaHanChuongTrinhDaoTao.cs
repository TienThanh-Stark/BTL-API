using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class VGiaHanChuongTrinhDaoTao
{
    public string? TenChuongTrinh { get; set; }

    public string? MaChuongTrinhDaoTao { get; set; }

    public string? SoQuyetDinhGiaHan { get; set; }

    public DateOnly? NgayBanHanhVanBanGiaHan { get; set; }

    public int? GiaHanLanThu { get; set; }
}
