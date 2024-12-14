using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHinhThucTuyenDung
{
    public int IdHinhThucTuyenDung { get; set; }

    public string? HinhThucTuyenDung { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinViecLamSauTotNghiep> TbThongTinViecLamSauTotNghieps { get; set; } = new List<TbThongTinViecLamSauTotNghiep>();
}
