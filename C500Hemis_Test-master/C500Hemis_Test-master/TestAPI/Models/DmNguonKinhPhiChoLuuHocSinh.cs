using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmNguonKinhPhiChoLuuHocSinh
{
    public int IdNguonKinhPhiChoLuuHocSinh { get; set; }

    public string? NguonKinhPhiChoLuuHocSinh { get; set; }

    public virtual ICollection<TbLuuHocSinhSinhVienNn> TbLuuHocSinhSinhVienNns { get; set; } = new List<TbLuuHocSinhSinhVienNn>();
}
