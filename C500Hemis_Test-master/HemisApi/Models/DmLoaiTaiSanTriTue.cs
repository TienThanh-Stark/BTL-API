using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiTaiSanTriTue
{
    public int IdLoaiTaiSanTriTue { get; set; }

    public string? LoaiTaiSanTriTue { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbTaiSanTriTue> TbTaiSanTriTues { get; set; } = new List<TbTaiSanTriTue>();
}
