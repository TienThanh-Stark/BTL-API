using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiViPham
{
    public int IdLoaiViPham { get; set; }

    public string? LoaiViPham { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinViPham> TbThongTinViPhams { get; set; } = new List<TbThongTinViPham>();
}
