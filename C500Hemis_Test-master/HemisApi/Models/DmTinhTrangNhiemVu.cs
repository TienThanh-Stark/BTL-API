using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTinhTrangNhiemVu
{
    public int IdTinhTrangNhiemVu { get; set; }

    public string? TinhTrangNhiemVu { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHoatDongBaoVeMoiTruong> TbHoatDongBaoVeMoiTruongs { get; set; } = new List<TbHoatDongBaoVeMoiTruong>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; } = new List<TbNhiemVuKhcn>();
}
