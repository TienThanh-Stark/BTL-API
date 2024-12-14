using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTrinhDoLyLuanChinhTri
{
    public int IdTrinhDoLyLuanChinhTri { get; set; }

    public string? TenTrinhDoLyLuanChinhTri { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
