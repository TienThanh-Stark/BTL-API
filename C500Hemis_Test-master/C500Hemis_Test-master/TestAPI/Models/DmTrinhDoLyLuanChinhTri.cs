using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmTrinhDoLyLuanChinhTri
{
    public int IdTrinhDoLyLuanChinhTri { get; set; }

    public string? TenTrinhDoLyLuanChinhTri { get; set; }

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
