using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmNganhKinhTe
{
    public int IdNganhKinhTe { get; set; }

    public string? Cap1 { get; set; }

    public string? NganhKinhTe { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; } = new List<TbChuyenGiaoCongNgheVaDaoTao>();
}
