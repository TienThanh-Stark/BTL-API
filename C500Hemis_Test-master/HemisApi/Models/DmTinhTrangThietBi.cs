using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTinhTrangThietBi
{
    public int IdTinhTrangThietBi { get; set; }

    public string? TinhTrangThietBi { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChiTietTaiSanDonVi> TbChiTietTaiSanDonVis { get; set; } = new List<TbChiTietTaiSanDonVi>();
}
