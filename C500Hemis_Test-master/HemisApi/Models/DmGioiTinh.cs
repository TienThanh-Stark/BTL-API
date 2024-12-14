using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmGioiTinh
{
    public int IdGioiTinh { get; set; }

    public string? GioiTinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
