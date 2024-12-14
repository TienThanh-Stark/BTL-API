using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTinhTrangHopDong
{
    public int IdTinhTrangHopDong { get; set; }

    public string? TinhTrangHopDong { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHopDong> TbHopDongs { get; set; } = new List<TbHopDong>();
}
