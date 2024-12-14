using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiLuuHocSinh
{
    public int IdLoaiLuuHocSinh { get; set; }

    public string? LoaiLuuHocSinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbLuuHocSinhSinhVienNn> TbLuuHocSinhSinhVienNns { get; set; } = new List<TbLuuHocSinhSinhVienNn>();
}
