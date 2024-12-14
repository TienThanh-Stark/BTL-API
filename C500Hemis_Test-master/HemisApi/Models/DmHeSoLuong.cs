using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHeSoLuong
{
    public int IdHeSoLuong { get; set; }

    public string? HeSoLuong { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDienBienLuong> TbDienBienLuongs { get; set; } = new List<TbDienBienLuong>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbPhuCap> TbPhuCaps { get; set; } = new List<TbPhuCap>();
}
