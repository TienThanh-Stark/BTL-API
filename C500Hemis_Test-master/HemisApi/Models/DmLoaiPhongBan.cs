using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiPhongBan
{
    public int IdLoaiPhongBan { get; set; }

    public string? LoaiPhongBan { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoCauToChuc> TbCoCauToChucs { get; set; } = new List<TbCoCauToChuc>();
}
