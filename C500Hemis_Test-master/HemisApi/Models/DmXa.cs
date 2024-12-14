using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmXa
{
    public int IdXa { get; set; }

    public string? TenXa { get; set; }

    public int? IdHuyen { get; set; }

    public virtual DmHuyen? IdHuyenNavigation { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
}
