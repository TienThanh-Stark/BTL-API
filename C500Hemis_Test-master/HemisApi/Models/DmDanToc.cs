using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmDanToc
{
    public int IdDanToc { get; set; }

    public string? DanToc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
