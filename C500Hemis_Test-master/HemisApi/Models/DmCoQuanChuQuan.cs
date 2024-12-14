using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmCoQuanChuQuan
{
    public int IdCoQuanChuQuan { get; set; }

    public string? CoQuanChuQuan { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHoatDongBaoVeMoiTruong> TbHoatDongBaoVeMoiTruongs { get; set; } = new List<TbHoatDongBaoVeMoiTruong>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; } = new List<TbNhiemVuKhcn>();
}
