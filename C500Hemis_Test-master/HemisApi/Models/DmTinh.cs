using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTinh
{
    public int IdTinh { get; set; }

    public string? TenTinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<DmHuyen> DmHuyens { get; set; } = new List<DmHuyen>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
}
