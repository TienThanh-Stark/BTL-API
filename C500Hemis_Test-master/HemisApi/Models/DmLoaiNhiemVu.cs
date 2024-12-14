using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiNhiemVu
{
    public int IdLoaiNhiemVu { get; set; }

    public string? LoaiNhiemVu { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; } = new List<TbNhiemVuKhcn>();
}
