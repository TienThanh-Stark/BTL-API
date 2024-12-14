using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTonGiao
{
    public int IdTonGiao { get; set; }

    public string? TonGiao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
