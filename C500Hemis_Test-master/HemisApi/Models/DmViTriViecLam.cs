using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmViTriViecLam
{
    public int IdViTriViecLam { get; set; }

    public string? ViTriViecLam { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinViecLamSauTotNghiep> TbThongTinViecLamSauTotNghieps { get; set; } = new List<TbThongTinViecLamSauTotNghiep>();
}
