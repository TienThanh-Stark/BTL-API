using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmChucDanhNckh
{
    public int IdChucDanhNghienCuuKhoaHoc { get; set; }

    public string? ChucDanhNghienCuuKhoaHoc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();
}
