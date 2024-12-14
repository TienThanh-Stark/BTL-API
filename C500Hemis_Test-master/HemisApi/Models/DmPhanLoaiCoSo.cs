using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmPhanLoaiCoSo
{
    public int IdPhanLoaiCoSo { get; set; }

    public string? PhanLoaiCoSo { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();
}
