using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbKhoanTrichLapQuy
{
    public int IdKhoanTrichLapQuy { get; set; }

    public string? MaKhoanTrichLapQuy { get; set; }

    public string? TenKhoanTrichLapQuy { get; set; }

    public string? NamTaiChinh { get; set; }

    public int? SoTien { get; set; }
}
