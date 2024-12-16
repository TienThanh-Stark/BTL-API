using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmGioiTinh
{
    public int IdGioiTinh { get; set; }

    public string? GioiTinh { get; set; }

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
