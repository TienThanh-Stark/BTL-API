using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHinhThucTuyenSinh
{
    public int IdHinhThucTuyenSinh { get; set; }

    public string? HinhThucTuyenSinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDuLieuTrungTuyen> TbDuLieuTrungTuyens { get; set; } = new List<TbDuLieuTrungTuyen>();
}
