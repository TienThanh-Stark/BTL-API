using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbKhoanNopNganSach
{
    public int IdKhoanNopNganSach { get; set; }

    public string? MaKhoanNop { get; set; }

    public string? TenKhoanNopNganSach { get; set; }

    public int? SoTien { get; set; }

    public string? NamTaiChinh { get; set; }
}
