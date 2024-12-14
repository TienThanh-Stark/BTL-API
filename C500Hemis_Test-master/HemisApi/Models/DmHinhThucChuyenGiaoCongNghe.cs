using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHinhThucChuyenGiaoCongNghe
{
    public int IdHinhThucChuyenGiaoCongNghe { get; set; }

    public string? HinhThucChuyenGiaoCongNghe { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; } = new List<TbChuyenGiaoCongNgheVaDaoTao>();
}
