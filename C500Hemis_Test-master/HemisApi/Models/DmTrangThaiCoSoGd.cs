using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTrangThaiCoSoGd
{
    public int IdTrangThaiCoSoGd { get; set; }

    public string? TrangThaiCoSoGd { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoCauToChuc> TbCoCauToChucs { get; set; } = new List<TbCoCauToChuc>();
}
