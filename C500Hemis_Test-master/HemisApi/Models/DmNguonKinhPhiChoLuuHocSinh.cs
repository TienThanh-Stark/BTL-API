using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmNguonKinhPhiChoLuuHocSinh
{
    public int IdNguonKinhPhiChoLuuHocSinh { get; set; }

    public string? NguonKinhPhiChoLuuHocSinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbLuuHocSinhSinhVienNn> TbLuuHocSinhSinhVienNns { get; set; } = new List<TbLuuHocSinhSinhVienNn>();
}
