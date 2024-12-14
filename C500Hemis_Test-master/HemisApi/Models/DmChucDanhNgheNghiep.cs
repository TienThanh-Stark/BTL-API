using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmChucDanhNgheNghiep
{
    public int IdChucDanhNgheNghiep { get; set; }

    public string? ChucDanhNgheNghiep { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();
}
