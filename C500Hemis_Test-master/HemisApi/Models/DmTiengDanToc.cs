using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTiengDanToc
{
    public int IdTiengDanToc { get; set; }

    public string? TiengDanToc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbTrinhDoTiengDanToc> TbTrinhDoTiengDanTocs { get; set; } = new List<TbTrinhDoTiengDanToc>();
}
