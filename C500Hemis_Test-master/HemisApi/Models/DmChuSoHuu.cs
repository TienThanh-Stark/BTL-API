using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmChuSoHuu
{
    public int IdChuSoHuu { get; set; }

    public string? ChuSoHuu { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChiTietTaiSanDonVi> TbChiTietTaiSanDonVis { get; set; } = new List<TbChiTietTaiSanDonVi>();
}
