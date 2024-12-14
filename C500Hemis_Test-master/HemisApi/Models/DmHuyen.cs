using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHuyen
{
    public int IdHuyen { get; set; }

    public string? TenHuyen { get; set; }

    public int? IdTinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<DmXa> DmXas { get; set; } = new List<DmXa>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual DmTinh? IdTinhNavigation { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
}
